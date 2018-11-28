' Author: Keith Smith
' Date: 28 November 2018
' Description: Handles a database's dataset and displays it to the user in a web form.

Imports System.Data.OleDb
Imports System.Data
' Could write: System.Data.DataSet
' Necessary if object (DataSet) is defined
' in multiple namespaces with different
' definitions

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            ' Clicked a control, caused a reload, other action, etc.
            ' Results sent back to server
            
        Else
            ' First time the page loads
            BooksGridView.DataSource = getBooks()

            ' Tell to view/bind data
            BooksGridView.DataBind()
        End If

    End Sub

    ' Handles changing the page
    Protected Sub BooksGridView_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles BooksGridView.PageIndexChanging
        ' 1. Load the database
        BooksGridView.DataSource = getBooks()

        ' 2. Set the page
        BooksGridView.PageIndex = e.NewPageIndex

        ' 3. Bind the control
        BooksGridView.DataBind()



    End Sub

    Private Function getBooks() As DataSet
        ' Retrieve data from the database:
        ' 1. Connection
        ' 2. Retrieve Data
        ' 3. Close Connection

        ' Need objects:
        ' 1. Connection Object
        ' 2. Adapter
        ' 3. DataSet

        Dim BooksConnection As OleDbConnection
        Dim BooksDataAdapter As OleDbDataAdapter
        Dim BooksDataSet As New DataSet

        ' Lots can go wrong, use try/catch block
        Try
            BooksConnection = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" &
                                                  "Data Source=" & Server.MapPath("App_Data\RnrBooks.mdb"))
            BooksConnection.Open()

            ' 1. What to select (SELECT statement)
            ' 2. What to select from (database)
            BooksDataAdapter = New OleDbDataAdapter("SELECT * FROM Books",
                                                    BooksConnection)

            ' Reads from the connection and fills the dataset
            BooksDataAdapter.Fill(BooksDataSet)

            ' Close the connection
            BooksConnection.Close()
        Catch ex As OleDbException

        Catch ex As Exception

        End Try

        Return BooksDataSet

    End Function
End Class
