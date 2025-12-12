using Microsoft.Playwright;
using System.Threading.Tasks;
using Xunit;

namespace BPCalculator_E2ETest
{
    [Trait("TestCategory", "E2E")]
    public class bmi_e2etests
    {
        private static string BaseUrl => Environment.GetEnvironmentVariable("BASE_URL") ?? "http://localhost:53135"; // adjust if needed

        private async Task<IPage> LaunchPageAsync()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            await page.GotoAsync(BaseUrl);
            return page;
        }

        private async Task<string> SubmitBmiAsync(IPage page, string height, string weight)
        {
            await page.FillAsync("#BP_HeightCm", height);
            await page.FillAsync("#BP_WeightKg", weight);
            await page.ClickAsync("input[type='submit']");
            await page.WaitForTimeoutAsync(500); // small delay for result
            return await page.InnerTextAsync("form");
        }

        [Fact]
        public async Task ShouldCalculateNormalBmi()
        {
            var page = await LaunchPageAsync();
            var result = await SubmitBmiAsync(page, "170", "65");
            Assert.Contains("BMI: 22.5 (Normal)", result);
        }

        [Fact]
        public async Task ShouldCalculateUnderweightBmi()
        {
            var page = await LaunchPageAsync();
            var result = await SubmitBmiAsync(page, "180", "55");
            Assert.Contains("Underweight", result);
        }

        [Fact]
        public async Task ShouldCalculateObeseBmi()
        {
            var page = await LaunchPageAsync();
            var result = await SubmitBmiAsync(page, "160", "95");
            Assert.Contains("Obese", result);
        }
    }
}
