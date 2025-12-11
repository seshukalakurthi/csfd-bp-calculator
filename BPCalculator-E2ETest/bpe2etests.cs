using Microsoft.Playwright;
using System.Threading.Tasks;
using Xunit;

namespace BPCalculator_E2ETest
{
    // Add Trait so we can filter these tests out in CI
    [Trait("TestCategory", "E2E")]
    public class bpe2etests
    {
        private const string BaseUrl = "http://localhost:53135"; // adjust if needed

        private async Task<IPage> LaunchPageAsync()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            await page.GotoAsync(BaseUrl);
            return page;
        }

        private async Task<string> SubmitBpAsync(IPage page, string systolic, string diastolic)
        {
            await page.FillAsync("#BP_Systolic", systolic);
            await page.FillAsync("#BP_Diastolic", diastolic);
            await page.ClickAsync("input[type='submit']");
            await page.WaitForTimeoutAsync(500); // small delay for result
            return await page.InnerTextAsync("form");
        }

        [Fact]
        public async Task ShouldCalculateLowBloodPressure()
        {
            var page = await LaunchPageAsync();
            var result = await SubmitBpAsync(page, "85", "55");
            Assert.Contains("Low Blood Pressure", result);
        }

        [Fact]
        public async Task ShouldCalculateIdealBloodPressure()
        {
            var page = await LaunchPageAsync();
            var result = await SubmitBpAsync(page, "100", "60");
            Assert.Contains("Ideal Blood Pressure", result);
        }

        [Fact]
        public async Task ShouldCalculatePreHighBloodPressure()
        {
            var page = await LaunchPageAsync();
            var result = await SubmitBpAsync(page, "135", "85");
            Assert.Contains("Pre-High Blood Pressure", result);
        }

        [Fact]
        public async Task ShouldCalculateHighBloodPressure()
        {
            var page = await LaunchPageAsync();
            var result = await SubmitBpAsync(page, "150", "95");
            Assert.Contains("High Blood Pressure", result);
        }

        [Fact]
        public async Task ShouldShowValidationErrorWhenSystolicNotGreaterThanDiastolic()
        {
            var page = await LaunchPageAsync();
            var result = await SubmitBpAsync(page, "60", "80");
            Assert.Contains("Invalid Systolic Value", result);
        }
    }
}
