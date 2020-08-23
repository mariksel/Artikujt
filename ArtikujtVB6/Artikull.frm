VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "mscomct2.ocx"
Begin VB.Form ArtikullForm 
   Appearance      =   0  'Flat
   BackColor       =   &H80000005&
   Caption         =   "Artikull"
   ClientHeight    =   6270
   ClientLeft      =   120
   ClientTop       =   465
   ClientWidth     =   8115
   LinkTopic       =   "Form1"
   ScaleHeight     =   6270
   ScaleWidth      =   8115
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton artikullIRiButton 
      Caption         =   "Artikull i ri"
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
      Left            =   2280
      TabIndex        =   19
      Top             =   5520
      Width           =   1575
   End
   Begin VB.ComboBox TipiCombo 
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "Segoe UI Semibold"
         Size            =   9.75
         Charset         =   0
         Weight          =   600
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      ItemData        =   "Artikull.frx":0000
      Left            =   480
      List            =   "Artikull.frx":0002
      Style           =   2  'Dropdown List
      TabIndex        =   18
      Top             =   4440
      Width           =   3015
   End
   Begin VB.TextBox BarkodTextBox 
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "Segoe UI Semibold"
         Size            =   9.75
         Charset         =   0
         Weight          =   600
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   4320
      TabIndex        =   15
      Top             =   4440
      Width           =   3000
   End
   Begin VB.CheckBox KaTvshCheck 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      Caption         =   "Ka Tvsh?"
      BeginProperty Font 
         Name            =   "Segoe UI Semibold"
         Size            =   9.75
         Charset         =   0
         Weight          =   600
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H80000008&
      Height          =   255
      Left            =   4320
      TabIndex        =   14
      Top             =   2760
      Width           =   2895
   End
   Begin VB.Frame LlojFrame 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      Caption         =   "Lloj"
      ForeColor       =   &H80000008&
      Height          =   1095
      Left            =   480
      TabIndex        =   11
      Top             =   2640
      Width           =   3015
      Begin VB.OptionButton VendiOption 
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         Caption         =   "Vendi"
         BeginProperty Font 
            Name            =   "Segoe UI Semibold"
            Size            =   9.75
            Charset         =   0
            Weight          =   600
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   250
         Left            =   250
         TabIndex        =   13
         Top             =   700
         Width           =   1335
      End
      Begin VB.OptionButton ImportuarOption 
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         Caption         =   "Importuar"
         BeginProperty Font 
            Name            =   "Segoe UI Semibold"
            Size            =   9.75
            Charset         =   0
            Weight          =   600
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   250
         Left            =   250
         TabIndex        =   12
         Top             =   300
         Width           =   2415
      End
   End
   Begin VB.TextBox CmimiTextBox 
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "Segoe UI Semibold"
         Size            =   9.75
         Charset         =   0
         Weight          =   600
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   4320
      TabIndex        =   9
      Top             =   1800
      Width           =   3000
   End
   Begin MSComCtl2.DTPicker DataSkadencesPicker 
      Height          =   375
      Left            =   480
      TabIndex        =   8
      Top             =   1800
      Width           =   3015
      _ExtentX        =   5318
      _ExtentY        =   661
      _Version        =   393216
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "Segoe UI Semibold"
         Size            =   9.75
         Charset         =   0
         Weight          =   600
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Format          =   108789761
      CurrentDate     =   44058
   End
   Begin VB.CommandButton FshiButton 
      Caption         =   "Fshi"
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
      Left            =   6000
      TabIndex        =   6
      Top             =   5520
      Width           =   1575
   End
   Begin VB.TextBox NjesiaTextBox 
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "Segoe UI Semibold"
         Size            =   9.75
         Charset         =   0
         Weight          =   600
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   4320
      TabIndex        =   5
      Top             =   600
      Width           =   3000
   End
   Begin VB.TextBox EmriTextBox 
      Appearance      =   0  'Flat
      BeginProperty Font 
         Name            =   "Segoe UI Semibold"
         Size            =   9.75
         Charset         =   0
         Weight          =   600
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   480
      TabIndex        =   4
      Top             =   600
      Width           =   3000
   End
   Begin VB.CommandButton RuajButton 
      Caption         =   "Ruaj"
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
      Left            =   4200
      TabIndex        =   3
      Top             =   5520
      Width           =   1575
   End
   Begin VB.CommandButton KerkoButton 
      Caption         =   "Kerko"
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
      Left            =   480
      TabIndex        =   2
      Top             =   5520
      Width           =   1575
   End
   Begin VB.Label TipiLabel 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      BackStyle       =   0  'Transparent
      Caption         =   "Tipi"
      BeginProperty Font 
         Name            =   "Segoe UI Semibold"
         Size            =   9.75
         Charset         =   0
         Weight          =   600
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H80000008&
      Height          =   255
      Index           =   1
      Left            =   480
      TabIndex        =   17
      Top             =   4080
      Width           =   1095
   End
   Begin VB.Label BarkodLabel 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      BackStyle       =   0  'Transparent
      Caption         =   "Barkod"
      BeginProperty Font 
         Name            =   "Segoe UI Semibold"
         Size            =   9.75
         Charset         =   0
         Weight          =   600
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H80000008&
      Height          =   255
      Index           =   0
      Left            =   4320
      TabIndex        =   16
      Top             =   4080
      Width           =   1095
   End
   Begin VB.Label CmimiLabel 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      BackStyle       =   0  'Transparent
      Caption         =   "Cmimi"
      BeginProperty Font 
         Name            =   "Segoe UI Semibold"
         Size            =   9.75
         Charset         =   0
         Weight          =   600
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H80000008&
      Height          =   255
      Index           =   0
      Left            =   4320
      TabIndex        =   10
      Top             =   1440
      Width           =   1095
   End
   Begin VB.Label DataSkadencesLabel 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      BackStyle       =   0  'Transparent
      Caption         =   "Data Skadences"
      BeginProperty Font 
         Name            =   "Segoe UI Semibold"
         Size            =   9.75
         Charset         =   0
         Weight          =   600
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H80000008&
      Height          =   255
      Index           =   1
      Left            =   480
      TabIndex        =   7
      Top             =   1440
      Width           =   3015
   End
   Begin VB.Label NjesiaLabel 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      BackStyle       =   0  'Transparent
      Caption         =   "Njesia"
      BeginProperty Font 
         Name            =   "Segoe UI Semibold"
         Size            =   9.75
         Charset         =   0
         Weight          =   600
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H80000008&
      Height          =   255
      Index           =   1
      Left            =   4320
      TabIndex        =   1
      Top             =   240
      Width           =   1095
   End
   Begin VB.Label EmriLabel 
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      BackStyle       =   0  'Transparent
      Caption         =   "Emri"
      BeginProperty Font 
         Name            =   "Segoe UI Semibold"
         Size            =   9.75
         Charset         =   0
         Weight          =   600
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H80000008&
      Height          =   255
      Index           =   0
      Left            =   480
      TabIndex        =   0
      Top             =   240
      Width           =   1095
   End
End
Attribute VB_Name = "ArtikullForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Public mArtikull As Artikull



Public Sub CreateNewArtikull()
    Set mArtikull = New Artikull
    mArtikull.IsNew = True
End Sub




Private Sub artikullIRiButton_Click()
    CreateNewArtikull
    Reset
End Sub

Private Sub Form_Load()
    CreateNewArtikull
    TipiCombo.AddItem "Ushqimore"
    TipiCombo.AddItem "Bulmet"
    TipiCombo.AddItem "Pije"
    TipiCombo.AddItem "Embelsire"
    Reset
End Sub

Public Sub OpenForm()
    Reset
    Me.Show
End Sub

Private Sub Reset()
    

    FshiButton.Visible = Not mArtikull.IsNew


    EmriTextBox.text = mArtikull.Emri
    NjesiaTextBox.text = mArtikull.Njesia
    DataSkadencesPicker.Value = mArtikull.DataSkadences
    CmimiTextBox.text = Format$(mArtikull.Cmimi, "0.0########################")
    ImportuarOption.Value = mArtikull.mLloj = "I"
    VendiOption.Value = mArtikull.mLloj = "V"
    KaTvshCheck.Value = Abs(CInt(mArtikull.KaTvsh))
    SelectTipiComboBox (mArtikull.mTipi)
    BarkodTextBox.text = mArtikull.Barkod
End Sub



Private Sub FshiButton_Click()
    Dim repo As New Repository

    repo.DeleteArtikull Me.mArtikull

    repo.Dispose
    MsgBox "Artikulli u fshi me sukses", vbOKOnly, "Sukses"
    
    CreateNewArtikull
    Reset
End Sub

'#### Bindings Start  #####

Private Sub EmriTextBox_Change()
    mArtikull.Emri = EmriTextBox.text
End Sub

Private Sub NjesiaTextBox_Change()
    mArtikull.Njesia = NjesiaTextBox.text
End Sub

Private Sub DataSkadencesPicker_Change()
    mArtikull.DataSkadences = DataSkadencesPicker.Value
End Sub

Private Sub CmimiTextBox_Change()

    If IsNumeric(CmimiTextBox.text) Then
        If CDbl(CmimiTextBox.text) >= 0 Then
            Dim numTxt As String
            numTxt = Replace(CmimiTextBox.text, ",", ".")
            mArtikull.Cmimi = CDbl(numTxt)
        Else
            CmimiTextBox.text = CStr(mArtikull.Cmimi)
        End If
    Else
        CmimiTextBox.text = CStr(mArtikull.Cmimi)
    End If
End Sub



Private Sub ImportuarOption_Click()
    If ImportuarOption.Value Then
        mArtikull.mLloj = "I"
    End If
End Sub



Private Sub VendiOption_Click()
    If VendiOption.Value Then
        mArtikull.mLloj = "V"
    End If
End Sub

Private Sub KaTvshCheck_Click()
    mArtikull.KaTvsh = KaTvshCheck.Value
End Sub

Private Sub TipiCombo_Click()
    Select Case TipiCombo.text
        Case "Ushqimore"
             mArtikull.mTipi = "Ushqimore"
        Case "Bulmet"
             mArtikull.mTipi = "Bulmet"
        Case "Pije"
             mArtikull.mTipi = "Pije"
        Case "Embelsire"
             mArtikull.mTipi = "Embelsire"
    End Select
End Sub

Private Sub BarkodTextBox_Change()
    mArtikull.Barkod = BarkodTextBox.text
End Sub
 
'#### Bindings End #####


Private Sub KerkoButton_Click()
    KerkoForm.OpenForm
    Me.Hide
End Sub



Private Sub RuajButton_Click()
    
    If mArtikull.IsOnValidState Then
    
        Dim repo As New Repository
        If mArtikull.IsNew Then
            repo.AddArtikull Me.mArtikull
        Else
            repo.UpdateArtikull Me.mArtikull
        End If
        CreateNewArtikull
        Reset
        repo.Dispose
        MsgBox "Artikulli u ruajt me sukses", vbOKOnly, "Sukses"
    End If

End Sub



Public Function SelectTipiComboBox(vTipi As String)
    TipiCombo.ListIndex = -1
    Dim i As Integer
    For i = 0 To TipiCombo.ListCount - 1
        If TipiCombo.list(i) = vTipi Then
            TipiCombo.ListIndex = i
        End If
    Next
End Function

Private Sub Form_Unload(Cancel As Integer)
    ArtikujtModule.ExitApp
End Sub
