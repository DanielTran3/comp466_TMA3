using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// A container data class for comments, where a comment must have a name and text associated with it.
/// </summary>
public class FeedbackComments
{
    #region data
    private string _name;
    private string _comment;
    #endregion

    #region Constructors
    public FeedbackComments(string name, string comment)
    {
        _name = name;
        _comment = comment;
    }
    #endregion

    #region Getters and Setters
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
    #endregion
}