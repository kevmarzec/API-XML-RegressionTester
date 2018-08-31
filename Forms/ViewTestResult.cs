using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TestBuilder.Forms
{
    public partial class ViewTestResult : Form
    {
        public ViewTestResult(Models.TestResult result)
        {
            InitializeComponent();

            ctrlParameters.Editable = false;
            ctrlParameters.SetParameters(
                result
                    .Parameters?
                    .Select(p => (Models.Parameter)p)
                    .ToList());

            tbOutput.Text = result.Output;
            tbScript.Text = result.Script;

            switch(result.Verified)
            {
                case Models.ResultState.IsVerifiedResult:
                    tbOutput.BackColor = Color.LightBlue;
                    break;

                case Models.ResultState.FailedVerification:
                    tbOutput.BackColor = Color.LightSalmon;
                    tbVerified.BackColor = Color.LightGreen;
                    splitContainer2.Panel2Collapsed = false;
                    
                    // Get verified output
                    using(var db = new DataContext())
                    {
                        var verified = db
                                        .TestResults
                                        .OrderByDescending(r => r.TestTime)
                                        .FirstOrDefault(r => r.EcuId == result.EcuId && r.TestId == r.TestId && r.Verified == Models.ResultState.IsVerifiedResult);

                        if(verified != null)
                        {
                            tbVerified.Text = verified.Output;
                        }
                    }

                    break;

                case Models.ResultState.Verified:
                    tbOutput.BackColor = Color.LightGreen;
                    break;
            }
        }
    }
}
