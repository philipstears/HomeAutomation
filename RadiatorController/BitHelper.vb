''' <summary>
''' Provides helper methods for working with bits.
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class BitHelper
    Private Sub New()
    End Sub

    ''' <summary>
    ''' Flips the order of the bits in the passed-in byte.
    ''' </summary>
    ''' <param name="original">The byte whose bits should be flipped.</param>
    ''' <returns>A byte containing the flipped bits.</returns>
    Public Shared Function Flip(original As Byte) As Byte
        Return TABLE_FLIP(original)
    End Function

    Private Shared ReadOnly TABLE_FLIP As Byte() = {
        &H0, &H80, &H40, &HC0, &H20, &HA0,
        &H60, &HE0, &H10, &H90, &H50, &HD0,
        &H30, &HB0, &H70, &HF0, &H8, &H88,
        &H48, &HC8, &H28, &HA8, &H68, &HE8,
        &H18, &H98, &H58, &HD8, &H38, &HB8,
        &H78, &HF8, &H4, &H84, &H44, &HC4,
        &H24, &HA4, &H64, &HE4, &H14, &H94,
        &H54, &HD4, &H34, &HB4, &H74, &HF4,
        &HC, &H8C, &H4C, &HCC, &H2C, &HAC,
        &H6C, &HEC, &H1C, &H9C, &H5C, &HDC,
        &H3C, &HBC, &H7C, &HFC, &H2, &H82,
        &H42, &HC2, &H22, &HA2, &H62, &HE2,
        &H12, &H92, &H52, &HD2, &H32, &HB2,
        &H72, &HF2, &HA, &H8A, &H4A, &HCA,
        &H2A, &HAA, &H6A, &HEA, &H1A, &H9A,
        &H5A, &HDA, &H3A, &HBA, &H7A, &HFA,
        &H6, &H86, &H46, &HC6, &H26, &HA6,
        &H66, &HE6, &H16, &H96, &H56, &HD6,
        &H36, &HB6, &H76, &HF6, &HE, &H8E,
        &H4E, &HCE, &H2E, &HAE, &H6E, &HEE,
        &H1E, &H9E, &H5E, &HDE, &H3E, &HBE,
        &H7E, &HFE, &H1, &H81, &H41, &HC1,
        &H21, &HA1, &H61, &HE1, &H11, &H91,
        &H51, &HD1, &H31, &HB1, &H71, &HF1,
        &H9, &H89, &H49, &HC9, &H29, &HA9,
        &H69, &HE9, &H19, &H99, &H59, &HD9,
        &H39, &HB9, &H79, &HF9, &H5, &H85,
        &H45, &HC5, &H25, &HA5, &H65, &HE5,
        &H15, &H95, &H55, &HD5, &H35, &HB5,
        &H75, &HF5, &HD, &H8D, &H4D, &HCD,
        &H2D, &HAD, &H6D, &HED, &H1D, &H9D,
        &H5D, &HDD, &H3D, &HBD, &H7D, &HFD,
        &H3, &H83, &H43, &HC3, &H23, &HA3,
        &H63, &HE3, &H13, &H93, &H53, &HD3,
        &H33, &HB3, &H73, &HF3, &HB, &H8B,
        &H4B, &HCB, &H2B, &HAB, &H6B, &HEB,
        &H1B, &H9B, &H5B, &HDB, &H3B, &HBB,
        &H7B, &HFB, &H7, &H87, &H47, &HC7,
        &H27, &HA7, &H67, &HE7, &H17, &H97,
        &H57, &HD7, &H37, &HB7, &H77, &HF7,
        &HF, &H8F, &H4F, &HCF, &H2F, &HAF,
        &H6F, &HEF, &H1F, &H9F, &H5F, &HDF,
        &H3F, &HBF, &H7F, &HFF
    }
End Class
