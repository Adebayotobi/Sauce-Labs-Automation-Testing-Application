using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {
        [Test]
        public async Task BuyTShirt()
        {
            var contextOptions = new BrowserNewContextOptions
            {

            };
            var context = await Browser.NewContextAsync(contextOptions);
            var page = await context.NewPageAsync();

            await page.GotoAsync("https://www.saucedemo.com/");

            // Fill in the username and password fields
            await page.FillAsync("#user-name", "standard_user");
            await page.FillAsync("#password", "secret_sauce");

            // Click the login button
            await page.ClickAsync("#login-button");

            // Verify that the page URL is as expected after login
            Assert.That(page.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));

            // Click on an inventory item to view details
            await page.ClickAsync(".inventory_item_img");

            // Wait for the inventory details to be visible
            await page.WaitForSelectorAsync(".inventory_details");

            // Verify that the inventory details are displayed
            var inventory_detailsDisplayed = await page.IsVisibleAsync(".inventory_details");
            Assert.That(inventory_detailsDisplayed, Is.True);

            // Add an item to the cart
            await page.ClickAsync("#add-to-cart-sauce-labs-backpack");

            // Click on the shopping cart icon
            await page.ClickAsync(".shopping_cart_container");

            // Wait for the cart contents container to be visible
            await page.WaitForSelectorAsync(".cart_contents_container");

            // Verify that the cart page is displayed
            var CartPage = await page.IsVisibleAsync(".cart_contents_container");
            Assert.That(CartPage, Is.True);

            // Get the name of the item in the cart
            var tshirtItem = await page.QuerySelectorAsync(".cart_item .inventory_item_name");
            var tshirtName = await tshirtItem!.InnerTextAsync();
            Assert.That(tshirtName, Is.EqualTo("Sauce Labs Backpack"));

            // Click on the checkout button
            await page.ClickAsync(".checkout_button");

            // Wait for the checkout information container to be visible
            await page.WaitForSelectorAsync("#checkout_info_container");

            // Fill in the checkout information
            await page.FillAsync("#first-name", "Tobi");
            await page.FillAsync("#last-name", "Adebayo");
            await page.FillAsync("#postal-code", "100010");

            // Click on the continue button
            await page.ClickAsync("#continue");

            // Wait for the order summary to be visible
            await page.WaitForSelectorAsync(".summary_info");
            var OrderSummary = await page.IsVisibleAsync("#checkout_summary_container");
            Assert.That(OrderSummary, Is.True);

            // Verify that payment and shipping information are displayed
            var PaymentInformation = await page.IsVisibleAsync(".summary_info_label");
            Assert.That(PaymentInformation, "Payment Information");

            var ShippingInformation = await page.IsVisibleAsync(".summary_info_label");
            Assert.That(ShippingInformation, "Shipping Information");

            // Verify that the total price is displayed
            var TotalPrice = await page.IsVisibleAsync(".summary_info_label");
            Assert.That(TotalPrice, "Price Total");


            await page.ClickAsync("#finish");

            await page.WaitForSelectorAsync(".complete-header");
            var orderDisplayed = await page.IsVisibleAsync(".header_secondary_container");
            // Assert that the order is displayed
            Assert.That(orderDisplayed, Is.True);

            var headerDisplay = await page.IsVisibleAsync(".complete-header");
            // Assert that the header displays "Thank you for your order!"
            Assert.That(headerDisplay, Is.True, "Thank you for your order!");

            await page.ClickAsync("#back-to-products");
            await page.ClickAsync(".bm-burger-button");
            await page.ClickAsync("#logout_sidebar_link");

            var LoginLabel = await page.IsVisibleAsync(".login_logo");
            // Assert that the login label is visible and contains "Shipping Information"
            Assert.That(LoginLabel, Is.True, "Shipping Information");

            await context.CloseAsync();

        }
    }
}
