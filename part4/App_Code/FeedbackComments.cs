using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FeedbackComments
/// </summary>
public class FeedbackComments
{
    private string _name;
    private string _comment;
    public FeedbackComments(string name, string comment)
    {
        _name = name;
        _comment = comment;
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string Comment
    {
        get { return _comment; }
        set { _comment = value; }
    }
}