using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

internal class Program
{
	private static void Main(string[] args)
	{
		IWebDriver driver = new ChromeDriver();
		driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
		driver.Navigate().GoToUrl("http://books.toscrape.com/index.html?");
		IReadOnlyList<IWebElement> title = driver.FindElements(By.XPath("//article[@class='product_pod']/child::h3"));
		List<Item> data = new List<Item>();
		foreach (IWebElement element in title)
		{
			Console.WriteLine(element.Text);
			element.Click();
			var titleName = driver.FindElement(By.ClassName("product_main"));
			var productDescription = driver.FindElement(By.XPath("//div[@id='product_description']/following-sibling::p"));
			Console.WriteLine(titleName.Text);
			Console.WriteLine(productDescription.Text);

			data.Add(new Item() { Title = titleName.Text, ProductDescription = productDescription.Text });
			driver.Navigate().Back();
		}
		foreach(Item element in data)
		{
			Console.WriteLine(element);
		}
	}
}
/*
   IWebDriver driver = new ChromeDriver();
   driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");
   var title = driver.Title;
   driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(0);
		Console.WriteLine("NAME: " + title);
		var textBox = driver.FindElement(By.Name("my-text"));
		var submitButton = driver.FindElement(By.TagName("button"));
		textBox.SendKeys("Selenium");
		submitButton.Click();
		var message = driver.FindElement(By.Id("message"));
		var value = message.Text;
		Console.WriteLine(value);
		driver.Quit();
*/
public class Item
{
	public string Title { get; set; }
	public string ProductDescription { get; set; }
	public override string ToString()
	{
		return "Title: "+Title+"Product Description: \b"+ProductDescription;
	}
}