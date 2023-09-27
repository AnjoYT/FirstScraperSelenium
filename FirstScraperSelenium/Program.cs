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
		IReadOnlyList<IWebElement> title = driver.FindElements(By.XPath("//li[@class='col-xs-6 col-sm-4 col-md-3 col-lg-3']//h3//a"));
		List<Item> data = new List<Item>();
		foreach (IWebElement element in title)
		{
			element.Click();
			var titleName = driver.FindElement(By.XPath("//div[@class='col-sm-6 product_main']/child::h1"));
			var productDescription = driver.FindElement(By.XPath("//div[@id='product_description']/following-sibling::p"));
			//Console.WriteLine(titleName.Text);
			//Console.WriteLine(productDescription.Text);

			data.Add(new Item() { Title = titleName.Text, ProductDescription = productDescription.Text });
			driver.Navigate().Back();
		}
		foreach(Item element in data)
		{
			Console.WriteLine(element);
		}
		Console.WriteLine(data.Count);

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
		return "Title: "+Title+"\n\nProduct Description: \n"+ProductDescription+"\n";
	}
}