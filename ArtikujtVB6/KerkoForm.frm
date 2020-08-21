VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "mscomctl.ocx"
Begin VB.Form KerkoForm 
   Appearance      =   0  'Flat
   BackColor       =   &H80000005&
   Caption         =   "Kerko"
   ClientHeight    =   6330
   ClientLeft      =   120
   ClientTop       =   465
   ClientWidth     =   7950
   LinkTopic       =   "Kerko"
   ScaleHeight     =   6330
   ScaleWidth      =   7950
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton DilButton 
      Appearance      =   0  'Flat
      BackColor       =   &H80000007&
      Caption         =   "Dil"
      BeginProperty Font 
         Name            =   "Segoe UI Semibold"
         Size            =   9.75
         Charset         =   0
         Weight          =   600
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   450
      Left            =   360
      TabIndex        =   0
      Top             =   5640
      Width           =   1575
   End
   Begin MSComctlLib.ListView ArtikujtListView 
      Height          =   5415
      Left            =   0
      TabIndex        =   1
      Top             =   0
      Width           =   7935
      _ExtentX        =   13996
      _ExtentY        =   9551
      View            =   3
      LabelWrap       =   -1  'True
      HideSelection   =   0   'False
      FullRowSelect   =   -1  'True
      GridLines       =   -1  'True
      _Version        =   393217
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
      Appearance      =   0
      NumItems        =   3
      BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         Text            =   "Id"
         Object.Width           =   1235
      EndProperty
      BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         Alignment       =   2
         SubItemIndex    =   1
         Text            =   "Emri"
         Object.Width           =   3528
      EndProperty
      BeginProperty ColumnHeader(3) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         Alignment       =   2
         SubItemIndex    =   2
         Text            =   "Cmimi"
         Object.Width           =   2646
      EndProperty
   End
   Begin VB.Frame PagesFrame 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      BorderStyle     =   0  'None
      ForeColor       =   &H80000008&
      Height          =   615
      Left            =   2640
      TabIndex        =   2
      Top             =   5640
      Width           =   5295
      Begin VB.Label LabelBtn 
         Alignment       =   2  'Center
         Caption         =   "1"
         BeginProperty Font 
            Name            =   "Segoe UI Semibold"
            Size            =   9.75
            Charset         =   0
            Weight          =   600
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   300
         Index           =   0
         Left            =   0
         TabIndex        =   3
         Top             =   0
         Width           =   300
      End
   End
End
Attribute VB_Name = "KerkoForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False


Private artikujt As New Collection
Private PageButtons As New Collection




Private Sub DilButton_Click()

    ArtikullForm.CreateNewArtikull
    
    NavigeteToArtikullForm
    
End Sub






Private Sub Form_Load()
    
    Reset 1
End Sub


Public Sub Reset(Optional Index As Integer = 1)
    Dim pgnt As Pagination
    Dim repo As New Repository
    
    Set pgnt = repo.GetArtikujt(Index)
    
    Clear artikujt
    For Each artk In pgnt.Models
        artikujt.Add artk, Key(artk.id)
    Next
    
    ArtikujtListView.ListItems.Clear
    
    For Each artk In artikujt
        Dim list As ListItem
        Set list = ArtikujtListView.ListItems.Add(, Key(artk.id), artk.id)
        list.ListSubItems.Add , , artk.Emri
        list.ListSubItems.Add , , artk.Cmimi
        
    Next
    
    GeneratePageButtons pgnt.Pages
    
    
End Sub


Public Sub OpenForm()
    Reset 1
    Me.Show
    
End Sub


Private Sub GeneratePageButtons(Pages As Collection)

    ClearPageButtons
    Dim PageButton As VB.Label
    Dim leftMargin As Integer
    Dim backClr As Long
    Dim i As Integer
    i = 0
    leftMargin = 10
    For Each pag In Pages
        If i > 0 Then
            Load LabelBtn(i)
        End If
        Set PageButton = LabelBtn(i)
        'Me.Controls.Add("vb.label", "PageButton" & CStr(pag.Index))
        'PageButtons.Add PageButton

        backClr = 16448764
        If pag.IsActive Then
            backClr = 6863545
        End If
        
        With PageButton
            .Left = leftMargin
            .Top = 10
            .Width = 400
            .Height = 300
            .Visible = True
            .BackColor = backClr
            .Alignment = 2
            .BorderStyle = 1
            .Font.Name = "Segoe UI"
            .Font.Size = 10
            .Font.Bold = True
            .Enabled = True
            .BorderStyle = 0
            .Caption = CStr(pag.Index)
            Set .Container = PagesFrame
        End With
        leftMargin = leftMargin + 410
        i = i + 1
    Next

End Sub

Private Sub ClearPageButtons()
    For Each pagBtn In PageButtons
        Me.Controls.Remove (pagBtn.Name)
    Next
    
    Dim i As Integer
    For i = 1 To LabelBtn.Count - 1
      Unload LabelBtn(i)
    Next i
    
    Clear PageButtons
    
End Sub



Private Sub ArtikujtListView_ItemClick(ByVal Item As MSComctlLib.ListItem)
    Set ArtikullForm.mArtikull = artikujt.Item(Item.Key)
    
    NavigeteToArtikullForm
    
End Sub




Public Function Key(id As Integer) As String
    Key = "x" + CStr(id)
End Function

Private Sub NavigeteToArtikullForm()
    Me.Hide
    ArtikullForm.OpenForm
End Sub

Public Sub Clear(list As Collection)
    Dim i As Integer
    If Not list Is Nothing Then
        For i = 1 To list.Count
          list.Remove 1 ' Remove first item
        Next i
    End If
    
End Sub




Private Sub Form_Unload(Cancel As Integer)
    ArtikujtModule.ExitApp
End Sub


Private Sub LabelBtn_Click(Index As Integer)
    Reset Index + 1
End Sub


