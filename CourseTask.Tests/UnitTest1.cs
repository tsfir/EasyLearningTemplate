using System.Text;
using Moq;
namespace CourseTask.Tests;

public class Tests
{
    StringBuilder _ConsoleOutput;
    Mock<TextReader> _ConsoleInput;
    [SetUp]
    public void Setup()
    {
        _ConsoleOutput = new StringBuilder();
        var ConsoleOutputWriter = new StringWriter(_ConsoleOutput);
        Console.SetOut(ConsoleOutputWriter);
    
        _ConsoleInput = new Mock<TextReader>();
        Console.SetIn(_ConsoleInput.Object);
    }

    private MockSequence SetupUserResponse(params string[] userResponse)
    {
        var sequence = new MockSequence();
        foreach (var response in userResponse)
        {
            _ConsoleInput.InSequence(sequence).Setup(x => x.ReadLine()).Returns(response);
        }
        return sequence;
    }
    
    private string[] RunMainAndGetOutput()
    {
        
        Program.Main(new string[0]);
        return _ConsoleOutput.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
    }

    [Test]
    public void Main_EnterNameAndWriteHello()
    {
        // WRITE HERE THE INPUTS FOR THE READLINES
        // FOR EXAMPLE SetupUserResponse("John",20);
        SetupUserResponse(   );

        // WRITE HERE THE EXPECTED OUTPUT FROM THE WRITELINES
        // var expectedOutput = new string[] { "Enter your name:", "Hello, John!" };
        var expectedOutput = new string[] {  };
        
        // PERFORM THE TEST
        var output = RunMainAndGetOutput();
        foreach(var i in Enumerable.Range(0, expectedOutput.Length))
        {
            Assert.AreEqual(expectedOutput[i], output[i]);
        }   
    }
}