VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Pagination"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False


Public NumberOfPages As Integer
Public Pages As Collection
Public CurrentIndex As Integer

Private mModels As Collection

Property Get Models() As Collection
    Set Models = mModels
End Property

Property Set Models(mdls As Collection)
    Set mModels = mdls
    Set Pages = New Collection
    
    Dim i As Integer
    Dim pag As Page
    For i = 1 To NumberOfPages
        Set pag = New Page
        pag.Index = i
        pag.IsActive = (i = CurrentIndex)
        
        Pages.Add pag
        
    Next
End Property



