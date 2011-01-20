﻿using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;
using FileHelpers;

namespace Demos
{
    public class DemoFactory
    {
	    static DemoFile work;

        public static List<DemoCode> GetDemos()
        {
		    var demos = new List<DemoCode>();
            DemoCode demo;
demo = new DemoCode(new ReadFile(), "Read Delimited File", "Basic");
demo.CodeDescription = @"Example of how to read a Delimited File";
demos.Add(demo);
work = new DemoFile("Example.cs");
work.Contents = @"/// <summary>
/// Execute the engine and get some results
/// </summary>
public override void Run()
{
    var engine = new FileHelperEngine<Orders>();
    var records = engine.ReadFile(""Input.txt"");

    foreach (var record in records)
    {
        Console.WriteLine(record.CustomerID);
        Console.WriteLine(record.OrderDate.ToString(""dd/MM/yyyy""));
        Console.WriteLine(record.Freight);
    }
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("RecordClass.cs");
work.Contents = @"/// <summary>
/// Our class we are reading using FileHelpers,  the record breakdown
/// </summary>
[DelimitedRecord(""|"")]
public class Orders
{
    public int OrderID;

    public string CustomerID;

    [FieldConverter(ConverterKind.Date, ""ddMMyyyy"")]
    public DateTime OrderDate;

    public decimal Freight;
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("Input.txt");
work.Contents = @"10248|VINET|04071996|32.38
10249|TOMSP|05071996|11.61
10250|HANAR|08071996|65.83
10251|VICTE|08071996|41.34
";
work.Status = DemoFile.FileType.InputFile;
demo.Files.Add(work);
work = new DemoFile("example_easy.html");
work.Contents = @"        <h2>Easy Example </h2>
<blockquote>
<p>If you have a source file like this, separated by a |:</p>
${Input.txt}
<p>You first declare a Record Mapping Class:</p>
${RecordClass.cs}
<p>Finally you must to instantiate a FileHelperEngine and read or write files:</p>
${Example.cs}
<p>Now you have an Orders array named <span class=""cs-literal"">res</span> where
every item in the array is an Order object. If you want to access one of the fields
let the Visual Studio IntelliSense bring up the field names for you.</p>
<blockquote>
<img height=""93"" src=""${URL}vs_orders.png"" width=""165"" alt=""Visual studio intellisense""/>
</blockquote>
         
";
work.Status = DemoFile.FileType.HtmlFile;
demo.Files.Add(work);

demo = new DemoCode(new WriteFile(), "Write Delimited File", "Basic");
demo.CodeDescription = @"Example of how to write a Delimited File";
demos.Add(demo);
work = new DemoFile("Example.cs");
work.Contents = @"var engine = new FileHelperEngine<Orders>();

var orders = new List<Orders>();

var order1 = new Orders() {OrderID = 1, CustomerID = ""AIRG"", Freight = 82.43M, OrderDate = new DateTime(2009,05,01)};
var order2 = new Orders() {OrderID = 2, CustomerID = ""JSYV"", Freight = 12.22M, OrderDate = new DateTime(2009,05,02)};

orders.Add(order1);
orders.Add(order2);

engine.WriteFile(""Output.Txt"", orders);
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("RecordClass.cs");
work.Contents = @"/// <summary>
/// Layout for a file delimited by |
/// </summary>
[DelimitedRecord(""|"")]
public class Orders
{
    public int OrderID;

    public string CustomerID;

    [FieldConverter(ConverterKind.Date, ""ddMMyyyy"")]
    public DateTime OrderDate;

    public decimal Freight;
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("Output.Txt");
work.Contents = @"";
work.Status = DemoFile.FileType.OutputFile;
demo.Files.Add(work);
work = new DemoFile("example_easy_write.html");
work.Contents = @"        <h2>Easy Write Example</h2>
<blockquote>
<p>To write an output file separated by a |:</p>
${Output.Txt}
<p>You use the same Record Mapping Class as you would to read it:</p>
${RecordClass.cs}
<p>Finally you must to instantiate a FileHelperEngine and write the file:</p>
${Example.cs}
<p>The classes you use could come from anywhere,  Linq to Entities,
SQL database reads, or in this case classes created within an application.
        
";
work.Status = DemoFile.FileType.HtmlFile;
demo.Files.Add(work);

demo = new DemoCode(new ReadFixedFile(), "Read Fixed File", "Basic");
demo.CodeDescription = @"Example of how to read a Fixed Length layout file (eg Cobol output)";
demos.Add(demo);
work = new DemoFile("Example.cs");
work.Contents = @"/// <summary>
/// Execute the engine and get some results
/// </summary>
public override void Run()
{
    var engine = new FixedFileEngine<Customer>();
    Customer[] result = engine.ReadFile(""input.txt"");

    foreach (var detail in result)
    {
        Console.WriteLine("" Client: {0},  Name: {1}"", detail.CustId, detail.Name);
    }

}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("RecordClass.cs");
work.Contents = @"/// <summary>
/// Our class we are reading using FileHelpers,  the record breakdown
/// </summary>
[FixedLengthRecord()]
public class Customer
{
    [FieldFixedLength(5)]
    public int CustId;

    [FieldFixedLength(30)]
    [FieldTrim(TrimMode.Both)]
    public string Name;

    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, ""ddMMyyyy"")]
    public DateTime AddedDate;

}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("Input.txt");
work.Contents = @"01010 Alfreds Futterkiste          13122005
12399 Ana Trujillo Emparedados y   23012000
00011 Antonio Moreno Taquería      21042001
51677 Around the Horn              13051998
99999 Berglunds snabbköp           02111999
";
work.Status = DemoFile.FileType.InputFile;
demo.Files.Add(work);
work = new DemoFile("example_fixedengine.html");
work.Contents = @"         <h2>Fixed File Engine</h2>
<p>Lets start with a simple data:</p>
${Input.txt}
<p>An simple example layout:</p>
${RecordClass.cs}
<p>Let see the result:</p>
${Console}
         
";
work.Status = DemoFile.FileType.HtmlFile;
demo.Files.Add(work);

demo = new DemoCode(new MultipleDelimiters(), "Multiple Delimiters", "Advanced");
demo.CodeDescription = @"Write a file with different delimiters using the same record";
demos.Add(demo);
work = new DemoFile("RunEngine.cs");
work.Contents = @"/// <summary>
/// Run an example of writing a delimited file and 
/// changing the delimiter to show how it is done.
/// </summary>
public override void Run()
{
    var customers = CreateCustomers();

    var engine = new DelimitedFileEngine<CustomersVerticalBar>();
    //  write out customers using a vertical bar delimiter (default)
    engine.WriteFile(""Out_Vertical.txt"", customers);

    // Change the delimiter to semicolon and write that out
    engine.Options.Delimiter = "";"";
    engine.WriteFile(""Out_SemiColon.txt"", customers);

    // Change the delimiter to a tab and write that out
    engine.Options.Delimiter = ""\t"";
    engine.WriteFile(""Out_Tab.txt"", customers);

}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("CreateCustomers.cs");
work.Contents = @"        /// <summary>
        /// This routine reads the data and creates an array of Customers for our samples
        /// </summary>
        /// <returns>Array of customers</returns>
        private CustomersVerticalBar[] CreateCustomers()
        {
            //  6 records of sample data to parse
            string tempCustomers = @""ALFKI|Alfreds Futterkiste|Maria Anders|Sales Representative|Obere Str. 57|Berlin|Germany
ANATR|Emparedados y Helados|Ana Trujillo|Owner|Avda. Constitución 2222|México D.F.|Mexico
ANTON|Antonio Moreno Taquería|Antonio Moreno|Owner|Mataderos  2312|México D.F.|Mexico
BERGS|Berglunds snabbköp|Christina Berglund|Administrator|Berguvsvägen  8|Luleå|Sweden
BLAUS|Blauer Delikatessen|Hanna Moos|Sales Rep|Forsterstr. 57|Mannheim|Germany
BOLID|Bólido Comidas preparadas|Martín Sommer|Owner|C/ Araquil, 67|Madrid|Spain"";

            // use the common engine to break down the records above
            return CommonEngine.ReadString<CustomersVerticalBar>(tempCustomers);
        }
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("CustomersVerticalBar.cs");
work.Contents = @"/// <summary>
/// Sample class that is delimited by | default
/// </summary>
/// <remarks>
/// Order of fields in the class is the same as the order in the file
/// </remarks>
[DelimitedRecord(""|"")]
public class CustomersVerticalBar
{
    public string CustomerID;
    public string CompanyName;
    public string ContactName;
    public string ContactTitle;
    public string Address;
    public string City;
    public string Country;

    //-> To display in the PropertyGrid.
    public override string ToString()
    {
        return CustomerID + "" - "" + CompanyName + "", "" + ContactName;
    }
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("example_delimited_engine.html");
work.Contents = @"<h2>Delimited File Engine</h2>
 *<p>With this cool feature you can simply change some of the record definitions at run time.</p>
 *<p>Lets start with a simple example:</p>
 *${CustomersVerticalBar.cs}
 *<p>After working with this file for a while, and you need to export the
 *data in this format <b>but delimited by "";"" and ""|""</b></p>
 *<p>This is how easy its is:</p>
 *${RunEngine.cs}
 
";
work.Status = DemoFile.FileType.HtmlFile;
demo.Files.Add(work);

demo = new DemoCode(new MultiRecordSample(), "Multi Record Processing", "Advanced");
demo.CodeDescription = @"Read or write a file with many different layouts";
demos.Add(demo);
work = new DemoFile("Input.txt");
work.Contents = @"10248|VINET|5|04071996|01081996|16071996|3|32.38  
10249|TOMSP|6|05071996|16081996|10071996|1|11.61
ALFKI;Alfreds Futterkiste;Maria Anders;Sales Representative;Obere Str. 57;Berlin;Germany
ANATR;Ana Trujillo Emparedados y helados;Ana Trujillo;Owner;Avda. de la Constitución 2222;México D.F.;Mexico
10250|HANAR|4|08071996|05081996|12071996|2|65.83
10111314012345
11101314123456
10251|VICTE|3|08071996|05081996|15071996|1|41.34
11121314901234
10101314234567
ANTON;Antonio Moreno Taquería;Antonio Moreno;Owner;Mataderos  2312;México D.F.;Mexico
BERGS;Berglunds snabbköp;Christina Berglund;Order Administrator;Berguvsvägen  8;Luleå;Sweden

";
work.Status = DemoFile.FileType.InputFile;
demo.Files.Add(work);
work = new DemoFile("RunEngine.cs");
work.Contents = @"/// <summary>
/// The idea of this engine is to parse files with different record types
/// (this engine doesn't use any hierarical structure like the
/// master-details, all the records are in linear relation for it).
/// With the MultiRecordEngine you can parse also mixed delimited and
/// fixed length records.
/// </summary>
public override void Run()
{
    MultiRecordEngine engine;

    engine = new MultiRecordEngine(typeof(Orders),
                                    typeof(Customer),
                                    typeof(SampleType));
    engine.RecordSelector = new RecordTypeSelector(CustomSelector);

    object[] res = engine.ReadFile(""Input.txt"");

    foreach (object rec in res)
        Console.WriteLine(res.ToString());

}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("Selector.cs");
work.Contents = @"/// <summary>
/// This is the selector that determines the record type based on
/// whatever criteria you write
/// </summary>
/// <param name=""engine"">Engine that is processing file</param>
/// <param name=""record"">Record read from input</param>
/// <returns>Record to accept this record</returns>
Type CustomSelector(MultiRecordEngine engine, string record)
{
    if (record.Length == 0)
        return null;

    if (Char.IsLetter(record[0]))
        return typeof(Customer);
    else if (record.Length == 14)
        return typeof(SampleType);
    else
        return typeof(Orders);
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("Customer.cs");
work.Contents = @"/// <summary>
/// Sample class that is delimited by | default
/// </summary>
/// <remarks>
/// Order of fields in the class is the same as the order in the file
/// </remarks>
[DelimitedRecord("";"")]
public class Customer
{
    public string CustomerID;
    public string CompanyName;
    public string ContactName;
    public string ContactTitle;
    public string Address;
    public string City;
    public string Country;

    //-> To display in the PropertyGrid.
    public override string ToString()
    {
        return CustomerID + "" - "" + CompanyName + "", "" + ContactName;
    }
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("SampleType.cs");
work.Contents = @"/// <summary>
/// Sample class that is Fixed length and has vrious data
/// </summary>
[FixedLengthRecord]
public class SampleType
{
    [FieldFixedLength(8)]
    [FieldConverter(ConverterKind.Date, ""ddMMyyyy"")]
    public DateTime Field1;

    [FieldFixedLength(3)]
    [FieldAlign(AlignMode.Left, ' ')]
    [FieldTrim(TrimMode.Both)]
    public string Field2;

    [FieldFixedLength(3)]
    [FieldAlign(AlignMode.Right, '0')]
    [FieldTrim(TrimMode.Both)]
    public int Field3;
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("Orders.cs");
work.Contents = @"/// <summary>
/// Sample class that is breaks up a vertical bar delimitted file
/// </summary>
[DelimitedRecord(""|"")]
public class Orders
{
    public int OrderID;

    public string CustomerID;

    public int EmployeeID;

    public DateTime OrderDate;

    public DateTime RequiredDate;

    [FieldNullValue(typeof(DateTime), ""2005-1-1"")]
    public DateTime ShippedDate;

    public int ShipVia;

    public decimal Freight;
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("example_multirecords.html");
work.Contents = @"        <h2>Multi Record Engine Example</h2>
<blockquote>
<p>The idea of this engine is to parse files with different record types
(this engine doesn't use any hierarical structure like the master-details,
all the records are in linear relation for it).</p>
<p>With the MultiRecordEngine you can parse also mixed delimited and fixed
length records. For example, you can parse this strange file:</p>
${Input.txt}
<p>This file contains <b>three</b> record types; Customers (begins with letters, | delimited),
Orders (begin with numbers, ';' delimited) and the sample type of the first example.</p>
<p>To work with this engine you must create one instance of it in this way:</p>
${RunEngine.cs}
<p>In the res array you have all the records in the file, each one with the corresponding type.</p>
<p>And the Selector Method looks like this:</p>
${Selector.cs}
<p> here are the three classes that read the different records</p>
${Customer.cs}
<br/><br/>
${SampleType.cs}
<br/><br/>
${Orders.cs}
<p>Hope you find this useful.</p>
</blockquote>
         
";
work.Status = DemoFile.FileType.HtmlFile;
demo.Files.Add(work);

demo = new DemoCode(new EnumConverterDemo(), "Enum Converter Example", "Advanced");
demo.CodeDescription = @"When you have a string field in your files that can be better handled if you map it to an enum.";
demos.Add(demo);
work = new DemoFile("TheEnumerator.cs");
work.Contents = @"/// <summary>
/// Different titles describing position in company
/// </summary>
public enum CustomerTitle
{
    Owner,
    SalesRepresentative,
    MarketingManager
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("RunEngine.cs");
work.Contents = @"/// <summary>
/// Run an example of writing a delimited file and 
/// changing the delimiter to show how it is done.
/// </summary>
public override void Run()
{
    var engine = new DelimitedFileEngine<Customer>();

    //  Read input records, enumeration automatically converted
    Customer[] customers =  engine.ReadFile(""Input.txt"");

    foreach (var cust in customers)
    {
        Console.WriteLine(""Customer name {0} is a {1}"", cust.ContactName, cust.ContactTitle);
    }
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("Customers with Enum.cs");
work.Contents = @"/// <summary>
/// Sample customer class that is delimited by | default
/// </summary>
/// <remarks>
/// Notice last feild is our enumerator
/// </remarks>
[DelimitedRecord(""|"")]
public class Customer
{
    public string CustomerID;
    public string CompanyName;
    public string ContactName;
    public CustomerTitle ContactTitle;
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("Input.txt");
work.Contents = @"ALFKI|Alfreds Futterkiste|Maria Anders|SalesRepresentative
ANATR|Ana Trujillo Emparedados y helados|Ana Trujillo|Owner
FRANR|France restauration|Carine Schmitt|MarketingManager
ANTON|Antonio Moreno Taquería|Antonio Moreno|Owner
";
work.Status = DemoFile.FileType.InputFile;
demo.Files.Add(work);
work = new DemoFile("example_enumconverter.html");
work.Contents = @"         <h2>Enum Converter Example</h2>
<blockquote>
<p>Sometimes you have a string field in your files that can be better handled if you map it to an enum.</p>
<p>Thanks to <b>Derek Fluker,</b> you can automatically use an enum without defining any
converter. The FileHelpers library parses the field and performs a case insensitive
comparison to the enum values and assigns the correct one.</p>
<p>The customer file is an excellent sample:</p>
${Input.txt}
<p>The enum is:</p>
${TheEnumerator.cs}
<p>When defining your record class use the enum:</p>
${Customers with Enum.cs}
<p>Done !! you parse the file with:</p>
${RunEngine.cs}
</blockquote>
         
";
work.Status = DemoFile.FileType.HtmlFile;
demo.Files.Add(work);

demo = new DemoCode(new SimpleErrorHandlingDemo(), "Simple Error handling", "ErrorHandling");
demo.CodeDescription = @"Read the file or reject the whole file";
demos.Add(demo);
work = new DemoFile("RunEngine.cs");
work.Contents = @"/// <summary>
/// Run an example of running a file with an error through and
/// using a try catch to collect the error.
/// </summary>
/// <remarks>
/// In the standard mode you can catch the exceptions when something fails.
/// </remarks>
public override void Run()
{
    try
    {
        var engine = new DelimitedFileEngine<Customer>();

        //  This fails with not in enumeration error
        Customer[] customers = engine.ReadFile(""Input.txt"");

        // this will not happen because of the exception
        foreach (var cust in customers)
        {
            Console.WriteLine(""Customer name {0} is a {1}"",
                              cust.ContactName,
                              cust.ContactTitle);
        }
    }
    catch (Exception ex)
    {
        // Console.WriteLine(ex.ToString()); // with stack trace
        Console.WriteLine(ex.Message);
    }
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("Customers with Enum.cs");
work.Contents = @"/// <summary>
/// Sample customer class that is delimited by | default
/// </summary>
/// <remarks>
/// Notice last feild is our enumerator
/// </remarks>
[DelimitedRecord(""|"")]
public class Customer
{
    public string CustomerID;
    public string CompanyName;
    public string ContactName;
    public CustomerTitle ContactTitle;
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("Input.txt");
work.Contents = @"ALFKI|Alfreds Futterkiste|Maria Anders|SalesRepresentative
ANATR|Ana Trujillo Emparedados y helados|Ana Trujillo|NotInEnum
FRANR|France restauration|Carine Schmitt|MarketingManager
ANTON|Antonio Moreno Taquería|Antonio Moreno|Owner
";
work.Status = DemoFile.FileType.InputFile;
demo.Files.Add(work);
work = new DemoFile("TheEnumerator.cs");
work.Contents = @"/// <summary>
/// Different titles describing position in company
/// </summary>
public enum CustomerTitle
{
    Owner,
    SalesRepresentative,
    MarketingManager
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("example_errors_simple.html");
work.Contents = @"         <h2>Simple Error Handling</h2>
<blockquote>
<p>In the standard mode you can catch the exceptions when something fail.</p>
${RunEngine.cs}
<p>This approach not is bad but you lose some information about the current record
and you can't use the records array because is not assigned.</p>
<p>Example exception is:</p>
${Console}
</blockquote>
         
";
work.Status = DemoFile.FileType.HtmlFile;
demo.Files.Add(work);

demo = new DemoCode(new ErrorModeErrorHandlingDemo(), "ErrorMode Error handling", "ErrorHandling");
demo.CodeDescription = @"Read the file rejecting bad records";
demos.Add(demo);
work = new DemoFile("RunEngine.cs");
work.Contents = @"/// <summary>
/// Run an example of running a file with an error using the
/// ErrorMode option to capture bad records
/// </summary>
/// <remarks>
/// In the standard mode you can catch the exceptions when something fails.
/// </remarks>
public override void Run()
{
    var engine = new DelimitedFileEngine<Customer>();

    // Switch error mode on
    engine.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue;

    //  Only record that fails will not be present
    Customer[] customers = engine.ReadFile(""Input.txt"");

    // This will display error from line 2 of the file.
    foreach (ErrorInfo err in engine.ErrorManager.Errors)
    {
        Console.WriteLine();
        Console.WriteLine(""Error on Line number: {0}"", err.LineNumber);
        Console.WriteLine(""Record causing the problem: {0}"", err.RecordString);
        Console.WriteLine(""Complete exception information: {0}"", err.ExceptionInfo.ToString());
    }
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("Customers with Enum.cs");
work.Contents = @"/// <summary>
/// Sample customer class that is delimited by | default
/// </summary>
/// <remarks>
/// Notice last feild is our enumerator
/// </remarks>
[DelimitedRecord(""|"")]
public class Customer
{
    public string CustomerID;
    public string CompanyName;
    public string ContactName;
    public CustomerTitle ContactTitle;
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("Input.txt");
work.Contents = @"ALFKI|Alfreds Futterkiste|Maria Anders|SalesRepresentative
ANATR|Ana Trujillo Emparedados y helados|Ana Trujillo|NotInEnum
FRANR|France restauration|Carine Schmitt|MarketingManager
ANTON|Antonio Moreno Taquería|Antonio Moreno|Owner
";
work.Status = DemoFile.FileType.InputFile;
demo.Files.Add(work);
work = new DemoFile("TheEnumerator.cs");
work.Contents = @"/// <summary>
/// Different titles describing position in company
/// </summary>
public enum CustomerTitle
{
    Owner,
    SalesRepresentative,
    MarketingManager
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("example_errors_errormode.html");
work.Contents = @"         <h2>ErorMode Error Handling</h2>
<p><p>A more intelligent way is using the
<a href=""FileHelpers.ErrorMode.html"">ErrorMode</a>.SaveAndContinue
of the ErrorManager:</p>
${RunEngine.cs}
<p>Using the engine like this you have the good records in the records array and in
the ErrorManager you have the records with errors and can do wherever you want.</p>
         
";
work.Status = DemoFile.FileType.HtmlFile;
demo.Files.Add(work);

demo = new DemoCode(new IgnoreModeErrorHandlingDemo(), "Ignore Mode Error handling", "ErrorHandling");
demo.CodeDescription = @"Read the file dropping bad records";
demos.Add(demo);
work = new DemoFile("RunEngine.cs");
work.Contents = @"/// <summary>
/// Run an example of running a file with an error using the
/// IgnoreMode option to silently drop bad records
/// </summary>
public override void Run()
{
    var engine = new DelimitedFileEngine<Customer>();

    // Switch error mode on
    engine.ErrorManager.ErrorMode = ErrorMode.IgnoreAndContinue;

    //  This fails with not in enumeration error
    Customer[] customers = engine.ReadFile(""Input.txt"");

    // This wont display anything, we have dropped it
    foreach (ErrorInfo err in engine.ErrorManager.Errors)
    {
        Console.WriteLine();
        Console.WriteLine(""Error on Line number: {0}"", err.LineNumber);
        Console.WriteLine(""Record causing the problem: {0}"", err.RecordString);
        Console.WriteLine(""Complete exception information: {0}"", err.ExceptionInfo.ToString());
    }

    // This will display only 3 of the four records
    foreach (var cust in customers)
    {
        Console.WriteLine(""Customer name {0} is a {1}"", cust.ContactName, cust.ContactTitle);
    }
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("Customers with Enum.cs");
work.Contents = @"/// <summary>
/// Sample customer class that is delimited by | default
/// </summary>
/// <remarks>
/// Notice last feild is our enumerator
/// </remarks>
[DelimitedRecord(""|"")]
public class Customer
{
    public string CustomerID;
    public string CompanyName;
    public string ContactName;
    public CustomerTitle ContactTitle;
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("Input.txt");
work.Contents = @"ALFKI|Alfreds Futterkiste|Maria Anders|SalesRepresentative
ANATR|Ana Trujillo Emparedados y helados|Ana Trujillo|NotInEnum
FRANR|France restauration|Carine Schmitt|MarketingManager
ANTON|Antonio Moreno Taquería|Antonio Moreno|Owner
";
work.Status = DemoFile.FileType.InputFile;
demo.Files.Add(work);
work = new DemoFile("TheEnumerator.cs");
work.Contents = @"/// <summary>
/// Different titles describing position in company
/// </summary>
public enum CustomerTitle
{
    Owner,
    SalesRepresentative,
    MarketingManager
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("example_errors_ignore.html");
work.Contents = @"         <h2>Ignore and Continue Error Handling</h2>
<p>Another option is to ignore the errors and continue. Here is an example:</p>
${RunEngine.cs}
<p>In the records array you only have the good records.</p>
         
";
work.Status = DemoFile.FileType.HtmlFile;
demo.Files.Add(work);

demo = new DemoCode(new ErrorSaveErrorHandlingDemo(), "ErrorMode saving Errors", "ErrorHandling");
demo.CodeDescription = @"Read the file saving bad records";
demos.Add(demo);
work = new DemoFile("RunEngine.cs");
work.Contents = @"/// <summary>
/// Run an example of running a file with an error using the
/// ErrorMode option to capture bad records and then saving them
/// </summary>
public override void Run()
{
    var engine = new DelimitedFileEngine<Customer>();

    // Switch error mode on
    engine.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue;

    //  This fails with not in enumeration error
    Customer[] customers = engine.ReadFile(""Input.txt"");

    if (engine.ErrorManager.HasErrors)
        engine.ErrorManager.SaveErrors(""errors.out"");
    LoadErrors();
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("LoadErrors.cs");
work.Contents = @"/// <summary>
/// Load errors and display on console
/// </summary>
private void LoadErrors()
{

    // sometime later you can read it back
    ErrorInfo[] errors = ErrorManager.LoadErrors(""errors.out"");

    // This will display error from line 2 of the file.
    foreach (var err in errors)
    {
        Console.WriteLine();
        Console.WriteLine(""Error on Line number: {0}"", err.LineNumber);
        Console.WriteLine(""Record causing the problem: {0}"", err.RecordString);
        Console.WriteLine(""Complete exception information: {0}"", err.ExceptionInfo.ToString());
    }
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("Customers with Enum.cs");
work.Contents = @"/// <summary>
/// Sample customer class that is delimited by | default
/// </summary>
/// <remarks>
/// Notice last feild is our enumerator
/// </remarks>
[DelimitedRecord(""|"")]
public class Customer
{
    public string CustomerID;
    public string CompanyName;
    public string ContactName;
    public CustomerTitle ContactTitle;
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("Input.txt");
work.Contents = @"ALFKI|Alfreds Futterkiste|Maria Anders|SalesRepresentative
ANATR|Ana Trujillo Emparedados y helados|Ana Trujillo|NotInEnum
FRANR|France restauration|Carine Schmitt|MarketingManager
ANTON|Antonio Moreno Taquería|Antonio Moreno|Owner
";
work.Status = DemoFile.FileType.InputFile;
demo.Files.Add(work);
work = new DemoFile("TheEnumerator.cs");
work.Contents = @"/// <summary>
/// Different titles describing position in company
/// </summary>
public enum CustomerTitle
{
    Owner,
    SalesRepresentative,
    MarketingManager
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("Errors.out");
work.Contents = @"";
work.Status = DemoFile.FileType.OutputFile;
demo.Files.Add(work);
work = new DemoFile("example_errors_save.html");
work.Contents = @"         <h2>Saving and Loading Errors</h2>
<blockquote>
<p>One interesting feature is the method in the ErrorManager to save the errors to a file,
you can do this as follows:</p>
${RunEngine.cs}
<p>To load a file with errors you can use the static method:</p>
${LoadErrors.cs}
</blockquote>
         
";
work.Status = DemoFile.FileType.HtmlFile;
demo.Files.Add(work);

demo = new DemoCode(new ReadBeforeEventSample(), "Read Before Event Handling", "Events");
demo.CodeDescription = @"Show how to implement read before event";
demos.Add(demo);
work = new DemoFile("RunEngine.cs");
work.Contents = @"/// <summary>
/// reads report.inp and skips all the records that are not detail records using a simple criteria
/// </summary>
public override void Run()
{
    var engine = new FileHelperEngine<OrdersFixed>();
    engine.BeforeReadRecord += new BeforeReadHandler<OrdersFixed>(BeforeEvent);
    var result = engine.ReadFile(""report.inp"");

    foreach (var value in result)
    {
        Console.WriteLine(""Customer: {0} Freight: {1}"", value.CustomerID, value.Freight);
    }
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("report.inp");
work.Contents = @"-----------------------------------------------------
              XXX Enterprise
-----------------------------------------------------
10249   TOMSP  05071996      11.61
10250   HANAR  08071996      65.83
10251   VICTE  08071996      41.34
                                       Page 1
-----------------------------------------------------
              YYY Enterprise
-----------------------------------------------------
10269   TOMSP  05071996      11.61
10230   HANAR  08071996      65.83
10151   VICTE  08071996      41.34

";
work.Status = DemoFile.FileType.InputFile;
demo.Files.Add(work);
work = new DemoFile("Report layout.cs");
work.Contents = @"/// <summary>
/// Layout of the records we want for the report in report.inp
/// </summary>
/// <remarks>
/// This only covers the detail records
/// </remarks>
[FixedLengthRecord(FixedMode.AllowVariableLength)]
[IgnoreEmptyLines]
public class OrdersFixed
{
    [FieldFixedLength(7)]
    public int OrderID;

    [FieldFixedLength(8)]
    public string CustomerID;

    [FieldFixedLength(8)]
    public DateTime OrderDate;

    [FieldFixedLength(11)]
    public decimal Freight;
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("EventHandler.cs");
work.Contents = @"private void BeforeEvent(EngineBase engine, BeforeReadEventArgs<OrdersFixed> e)
{
    if (e.RecordLine.StartsWith("" "") || e.RecordLine.StartsWith(""-""))
        e.SkipThisRecord = true;

    //  Sometimes changing the record line can be useful, for example to correct for
    //  a bad data layout.  Here is an example of this, commented out for this example

    //if (e.RecordLine.StartsWith("" ""))
    //   e.RecordLine = ""Be careful!"";
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);

demo = new DemoCode(new ReadAfterEventSample(), "Read After Event Handling", "Events");
demo.CodeDescription = @"Show how to implement read after event";
demos.Add(demo);
work = new DemoFile("RunEngine.cs");
work.Contents = @"/// <summary>
/// Read a simple file and ignore zero value freight using a Read After Event
/// </summary>
public override void Run()
{
    var engine = new FileHelperEngine<OrdersFixed>();
    engine.AfterReadRecord += new AfterReadHandler<OrdersFixed>(AfterEvent);

    var result = engine.ReadFile(""Input.txt"");

    foreach (var value in result)
    {
        Console.WriteLine(""Customer: {0} Freight: {1}"", value.CustomerID, value.Freight);
    }
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("Input.txt");
work.Contents = @"10249   TOMSP  05071996      11.61
10250   HANAR  08071996       0.00
10251   VICTE  08071996      41.34
10269   TOMSP  05071996      11.61
10230   HANAR  08071996      65.83
10151   VICTE  08071996      41.34

";
work.Status = DemoFile.FileType.InputFile;
demo.Files.Add(work);
work = new DemoFile("Report layout.cs");
work.Contents = @"/// <summary>
/// Layout of the all input records from Input.txt
/// </summary>
[FixedLengthRecord(FixedMode.AllowVariableLength)]
[IgnoreEmptyLines]
public class OrdersFixed
{
    [FieldFixedLength(7)]
    public int OrderID;

    [FieldFixedLength(8)]
    public string CustomerID;

    [FieldFixedLength(8)]
    public DateTime OrderDate;

    [FieldFixedLength(11)]
    public decimal Freight;
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("EventHandler.cs");
work.Contents = @"private void AfterEvent(EngineBase engine, AfterReadEventArgs<OrdersFixed> e)
{
    //  we want to drop all records with no freight
    if (e.Record.Freight == 0)
        e.SkipThisRecord = true;
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);

demo = new DemoCode(new WriteBeforeEventSample(), "Write Before Event Handling", "Events");
demo.CodeDescription = @"Show how to implement write before event";
demos.Add(demo);
work = new DemoFile("RunEngine.cs");
work.Contents = @"/// <summary>
/// Run a record through engine using the write event to filter out unwanted details
/// </summary>
public override void Run()
{
    var engine = new FileHelperEngine<OrdersFixed>();

    var result = engine.ReadFile(""Input.txt"");

    //  add our filter logic.
    engine.BeforeWriteRecord += new BeforeWriteHandler<OrdersFixed>(BeforeWriteEvent);
    engine.WriteFile(""output.txt"", result);
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("EventHandler.cs");
work.Contents = @"private void BeforeWriteEvent(EngineBase engine, BeforeWriteEventArgs<OrdersFixed> e)
{
    //  We only want clients with large frieght values
    if (e.Record.Freight < 40)
        e.SkipThisRecord = true;
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("Input.txt");
work.Contents = @"10249   TOMSP  05071996      11.61
10250   HANAR  08071996       0.00
10251   VICTE  08071996      41.34
10269   TOMSP  05071996      11.61
10230   HANAR  08071996      65.83
10151   VICTE  08071996      41.34

";
work.Status = DemoFile.FileType.InputFile;
demo.Files.Add(work);
work = new DemoFile("output.txt");
work.Contents = @"";
work.Status = DemoFile.FileType.OutputFile;
demo.Files.Add(work);
work = new DemoFile("Report layout.cs");
work.Contents = @"/// <summary>
/// Layout of the records we want for the report in Input.txt
/// </summary>
[FixedLengthRecord(FixedMode.AllowVariableLength)]
[IgnoreEmptyLines]
public class OrdersFixed
{
    [FieldFixedLength(7)]
    public int OrderID;

    [FieldFixedLength(8)]
    public string CustomerID;

    [FieldFixedLength(8)]
    public DateTime OrderDate;

    [FieldFixedLength(11)]
    public decimal Freight;
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);

demo = new DemoCode(new WriteAfterEventSample(), "Write After Event Handling", "Events");
demo.CodeDescription = @"Show how to implement write after event";
demos.Add(demo);
work = new DemoFile("RunEngine.cs");
work.Contents = @"/// <summary>
/// Run a record through engine using the write event to filter out unwanted details
/// </summary>
public override void Run()
{
    var engine = new FileHelperEngine<OrdersFixed>();

    var result = engine.ReadFile(""Input.txt"");

    //  add our filter logic.
    engine.AfterWriteRecord += new AfterWriteHandler<OrdersFixed>(AfterWriteEvent);
    engine.WriteFile(""output.txt"", result);
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("EventHandler.cs");
work.Contents = @"private void AfterWriteEvent(EngineBase engine, AfterWriteEventArgs<OrdersFixed> e)
{
   //  We only want clients with large frieght values
    if (e.Record.CustomerID == ""HANAR"" )
        e.RecordLine = ""Insufficient Access"";
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("Input.txt");
work.Contents = @"10249   TOMSP  05071996      11.61
10250   HANAR  08071996       0.00
10251   VICTE  08071996      41.34
10269   TOMSP  05071996      11.61
10230   HANAR  08071996      65.83
10151   VICTE  08071996      41.34

";
work.Status = DemoFile.FileType.InputFile;
demo.Files.Add(work);
work = new DemoFile("output.txt");
work.Contents = @"";
work.Status = DemoFile.FileType.OutputFile;
demo.Files.Add(work);
work = new DemoFile("Report layout.cs");
work.Contents = @"/// <summary>
/// Layout of the records we want for the report in Input.txt
/// </summary>
[FixedLengthRecord(FixedMode.AllowVariableLength)]
[IgnoreEmptyLines]
public class OrdersFixed
{
    [FieldFixedLength(7)]
    public int OrderID;

    [FieldFixedLength(8)]
    [FieldTrim(TrimMode.Both)]
    public string CustomerID;

    [FieldFixedLength(8)]
    public DateTime OrderDate;

    [FieldFixedLength(11)]
    public decimal Freight;
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);

demo = new DemoCode(new SimpleMasterDetailSample(), "Simple Master Detail sample", "MasterDetail");
demo.CodeDescription = @"Show how to implement Master detail reading using a selection subroutine";
demos.Add(demo);
work = new DemoFile("RunEngine.cs");
work.Contents = @"/// <summary>
/// Run a record through engine using a selector to create a master detail input
/// </summary>
public override void Run()
{
    var engine = new MasterDetailEngine<Customers, Orders>(new MasterDetailSelector(ExampleSelector));

    var result = engine.ReadFile(""Input.txt"");

    foreach (var group in result)
    {
        Console.WriteLine(""Customer: {0}"", group.Master.CustomerID);
        foreach (var detail in group.Details)
        {
            Console.WriteLine(""    Freight: {0}"", detail.Freight);
        }
    }
}

/// <summary>
/// Selector to determine whether we have a master or
/// detail record to import
/// </summary>
/// <param name=""record"">Alpha characters coming in</param>
/// <returns>Selector for master or detail record</returns>
FileHelpers.MasterDetail.RecordAction ExampleSelector(string record)
{
    if (record.Length < 2)
        return RecordAction.Skip;

    if (Char.IsLetter(record[0]))
        return FileHelpers.MasterDetail.RecordAction.Master;
    else
        return FileHelpers.MasterDetail.RecordAction.Detail;
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("Input.txt");
work.Contents = @"ALFKI|Alfreds Futterkiste|Maria Anders|Sales Representative|Obere Str. 57|Berlin|Germany
10248|ALFKI|5|04071996|01081996|16071996|3|32.38
10249|ALFKI|6|05071996|16081996|10071996|1|11.61
10251|ALFKI|3|08071996|05081996|15071996|1|41.34
ANATR|Ana Trujillo Emparedados y helados|Ana Trujillo|Owner|Avda. de la Constitución 2222|México D.F.|Mexico
10252|ANATR|4|09071996|06081996|11071996|2|51.3
ANTON|Antonio Moreno Taquería|Antonio Moreno|Owner|Mataderos  2312|México D.F.|Mexico

";
work.Status = DemoFile.FileType.InputFile;
demo.Files.Add(work);
work = new DemoFile("output.txt");
work.Contents = @"";
work.Status = DemoFile.FileType.OutputFile;
demo.Files.Add(work);
work = new DemoFile("Master layout.cs");
work.Contents = @"/// <summary>
/// Layout of the master records beginning with alpha characters in input
/// </summary>
[DelimitedRecord(""|"")]
public class Customers
{
    public string CustomerID;
    public string CompanyName;
    public string ContactName;
    public string ContactTitle;
    public string Address;
    public string City;
    public string Country;
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("Detail layout.cs");
work.Contents = @"/// <summary>
/// Layout of the detail records beginning with numerics in input
/// </summary>
[DelimitedRecord(""|"")]
public class Orders
{
    public int OrderID;
    public string CustomerID;
    public int EmployeeID;
    public DateTime OrderDate;
    public DateTime RequiredDate;
    public DateTime ShippedDate;
    public int ShipVia;
    public decimal Freight;
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);

demo = new DemoCode(new SecondMasterDetailSample(), "Master Detail sample", "MasterDetail");
demo.CodeDescription = @"Show how to implement Master detail reading where record contains characters";
demos.Add(demo);
work = new DemoFile("RunEngine.cs");
work.Contents = @"/// <summary>
/// Run a record through engine using a Common selector where master contains a characrter to create a master detail input
/// </summary>
public override void Run()
{
    var engine = new MasterDetailEngine<Customers, Orders>
                                 (CommonSelector.MasterIfContains, ""@"");
    // to Read use:
    var res = engine.ReadFile(""Input.txt"");

    // to Write use:
    engine.WriteFile(""Output.txt"", res);
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("Input.txt");
work.Contents = @"@ALFKI|Alfreds Futterkiste|Maria Anders|Sales Representative|Obere Str. 57|Berlin|Germany
10248|ALFKI|5|04071996|01081996|16071996|3|32.38
10249|ALFKI|6|05071996|16081996|10071996|1|11.61
10251|ALFKI|3|08071996|05081996|15071996|1|41.34
@ANATR|Ana Trujillo Emparedados y helados|Ana Trujillo|Owner|Avda. de la Constitución 2222|México D.F.|Mexico
10252|ANATR|4|09071996|06081996|11071996|2|51.3
@ANTON|Antonio Moreno Taquería|Antonio Moreno|Owner|Mataderos  2312|México D.F.|Mexico

";
work.Status = DemoFile.FileType.InputFile;
demo.Files.Add(work);
work = new DemoFile("Output.txt");
work.Contents = @"";
work.Status = DemoFile.FileType.OutputFile;
demo.Files.Add(work);
work = new DemoFile("Master layout.cs");
work.Contents = @"/// <summary>
/// Layout of the master records beginning with alpha characters in input
/// </summary>
[DelimitedRecord(""|"")]
[IgnoreEmptyLines]
public class Customers
{
    public string CustomerID;
    public string CompanyName;
    public string ContactName;
    public string ContactTitle;
    public string Address;
    public string City;
    public string Country;
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);
work = new DemoFile("Detail layout.cs");
work.Contents = @"/// <summary>
/// Layout of the detail records beginning with numerics in input
/// </summary>
[DelimitedRecord(""|"")]
public class Orders
{
    public int OrderID;
    public string CustomerID;
    public int EmployeeID;
    public DateTime OrderDate;
    public DateTime RequiredDate;
    public DateTime ShippedDate;
    public int ShipVia;
    public decimal Freight;
}
";
work.Language = NetLanguage.CSharp;
demo.Files.Add(work);

		
           return demos;
        }
    }
}


