using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Printing;

namespace Ismaroik.ImageCompare.WinForms
{

    /// <summary>
    /// An extension for RichTextBox suitable for printing.
    /// </summary>
    public class PrintableRichTextBox : RichTextBox
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct STRUCT_RECT
        {
            public Int32 left;
            public Int32 top;
            public Int32 right;
            public Int32 bottom;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct STRUCT_CHARRANGE
        {
            public Int32 cpMin;
            public Int32 cpMax;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct STRUCT_FORMATRANGE
        {
            public IntPtr hdc;
            public IntPtr hdcTarget;
            public STRUCT_RECT rc;
            public STRUCT_RECT rcPage;
            public STRUCT_CHARRANGE chrg;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CHARFORMAT
        {
            public int cbSize;
            public uint dwMask;
            public uint dwEffects;
            public int yHeight;
            public int yOffset;
            public int crTextColor;
            public byte bCharSet;
            public byte bPitchAndFamily;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public char[] szFaceName;

            // CHARFORMAT2 from here onwards.
            public short wWeight;
            public short sSpacing;
            public int crBackColor;
            public int LCID;
            public uint dwReserved;
            public short sStyle;
            public short wKerning;
            public byte bUnderlineType;
            public byte bAnimation;
            public byte bRevAuthor;
        }

        [DllImport("user32.dll")]
        private static extern Int32 SendMessage(IntPtr hWnd, Int32 msg,
            Int32 wParam, IntPtr lParam);

        // Windows Messages defines
        private const Int32 WM_USER = 0x400;
        private const Int32 EM_FORMATRANGE = WM_USER + 57;
        private const Int32 EM_GETCHARFORMAT = WM_USER + 58;
        private const Int32 EM_SETCHARFORMAT = WM_USER + 68;

        // Defines for EM_SETCHARFORMAT/EM_GETCHARFORMAT
        private const Int32 SCF_SELECTION = 0x0001;
        private const Int32 SCF_WORD = 0x0002;
        private const Int32 SCF_ALL = 0x0004;

        // Defines for STRUCT_CHARFORMAT member dwMask
        private const UInt32 CFM_BOLD = 0x00000001;
        private const UInt32 CFM_ITALIC = 0x00000002;
        private const UInt32 CFM_UNDERLINE = 0x00000004;
        private const UInt32 CFM_STRIKEOUT = 0x00000008;
        private const UInt32 CFM_PROTECTED = 0x00000010;
        private const UInt32 CFM_LINK = 0x00000020;
        private const UInt32 CFM_SIZE = 0x80000000;
        private const UInt32 CFM_COLOR = 0x40000000;
        private const UInt32 CFM_FACE = 0x20000000;
        private const UInt32 CFM_OFFSET = 0x10000000;
        private const UInt32 CFM_CHARSET = 0x08000000;
        private const UInt32 CFM_BACKCOLOR = 0x04000000;

        // Defines for STRUCT_CHARFORMAT member dwEffects
        private const UInt32 CFE_BOLD = 0x00000001;
        private const UInt32 CFE_ITALIC = 0x00000002;
        private const UInt32 CFE_UNDERLINE = 0x00000004;
        private const UInt32 CFE_STRIKEOUT = 0x00000008;
        private const UInt32 CFE_PROTECTED = 0x00000010;
        private const UInt32 CFE_LINK = 0x00000020;
        private const UInt32 CFE_AUTOCOLOR = 0x40000000;

        /// <summary>
        /// Calculate or render the contents of our RichTextBox for printing
        /// </summary>
        /// <param name="measureOnly">If true, only the calculation is performed,
        /// otherwise the text is rendered as well</param>
        /// <param name="e">The PrintPageEventArgs object from the
        /// PrintPage event</param>
        /// <param name="charFrom">Index of first character to be printed</param>
        /// <param name="charTo">Index of last character to be printed</param>
        /// <returns>(Index of last character that fitted on the
        /// page) + 1</returns>
        public int FormatRange(bool measureOnly, PrintPageEventArgs e,
            int charFrom, int charTo)
        {
            // Specify which characters to print
            STRUCT_CHARRANGE cr;
            cr.cpMin = charFrom;
            cr.cpMax = charTo;

            // Specify the area inside page margins
            STRUCT_RECT rc;
            rc.top = HundredthInchToTwips(e.MarginBounds.Top);
            rc.bottom = HundredthInchToTwips(e.MarginBounds.Bottom);
            rc.left = HundredthInchToTwips(e.MarginBounds.Left);
            rc.right = HundredthInchToTwips(e.MarginBounds.Right);

            // Specify the page area
            STRUCT_RECT rcPage;
            rcPage.top = HundredthInchToTwips(e.PageBounds.Top);
            rcPage.bottom = HundredthInchToTwips(e.PageBounds.Bottom);
            rcPage.left = HundredthInchToTwips(e.PageBounds.Left);
            rcPage.right = HundredthInchToTwips(e.PageBounds.Right);

            // Get device context of output device
            IntPtr hdc = e.Graphics.GetHdc();

            // Fill in the FORMATRANGE struct
            STRUCT_FORMATRANGE fr;
            fr.chrg = cr;
            fr.hdc = hdc;
            fr.hdcTarget = hdc;
            fr.rc = rc;
            fr.rcPage = rcPage;

            // Non-Zero wParam means render, Zero means measure
            Int32 wParam = (measureOnly ? 0 : 1);

            // Allocate memory for the FORMATRANGE struct and
            // copy the contents of our struct to this memory
            IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fr));
            Marshal.StructureToPtr(fr, lParam, false);

            // Send the actual Win32 message
            int res = SendMessage(Handle, EM_FORMATRANGE, wParam, lParam);

            // Free allocated memory
            Marshal.FreeCoTaskMem(lParam);

            // and release the device context
            e.Graphics.ReleaseHdc(hdc);

            return res;
        }
        /// <summary>
        /// Convert between 1/100 inch (unit used by the .NET framework)
        /// and twips (1/1440 inch, used by Win32 API calls)
        /// </summary>
        /// <param name="n">Value in 1/100 inch</param>
        /// <returns>Value in twips</returns>
        private Int32 HundredthInchToTwips(int n)
        {
            return (Int32)(n * 14.4);
        }
        /// <summary>
        /// Free cached data from rich edit control after printing
        /// </summary>
        public void FormatRangeDone()
        {
            IntPtr lParam = new IntPtr(0);
            SendMessage(Handle, EM_FORMATRANGE, 0, lParam);
        }

        /// <summary>
        /// Sets the font only for the selected part of the rich text box
        /// without modifying the other properties like size or style
        /// </summary>
        /// <param name="face">Name of the font to use</param>
        /// <returns>true on success, false on failure</returns>
        public bool SetSelectionFont(string face)
        {
            CHARFORMAT cf = new CHARFORMAT();
            cf.cbSize = Marshal.SizeOf(cf);
            cf.szFaceName = new char[32];
            cf.dwMask = CFM_FACE;
            face.CopyTo(0, cf.szFaceName, 0, Math.Min(31, face.Length));

            IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
            Marshal.StructureToPtr(cf, lParam, false);

            int res = SendMessage(Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam);
            return (res == 0);
        }

        /// <summary>
        /// Sets the font size only for the selected part of the rich text box
        /// without modifying the other properties like font or style
        /// </summary>
        /// <param name="size">new point size to use</param>
        /// <returns>true on success, false on failure</returns>
        public bool SetSelectionSize(int size)
        {
            CHARFORMAT cf = new CHARFORMAT();
            cf.cbSize = Marshal.SizeOf(cf);
            cf.dwMask = CFM_SIZE;
            // yHeight is in 1/20 pt
            cf.yHeight = size * 20;

            IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
            Marshal.StructureToPtr(cf, lParam, false);

            int res = SendMessage(Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam);
            return (res == 0);
        }

        /// <summary>
        /// Sets the bold style only for the selected part of the rich text box
        /// without modifying the other properties like font or size
        /// </summary>
        /// <param name="bold">make selection bold (true) or regular (false)</param>
        /// <returns>true on success, false on failure</returns>
        public bool SetSelectionBold(bool bold)
        {
            return SetSelectionStyle(CFM_BOLD, bold ? CFE_BOLD : 0);
        }

        /// <summary>
        /// Sets the italic style only for the selected part of the rich text box
        /// without modifying the other properties like font or size
        /// </summary>
        /// <param name="italic">make selection italic (true) or regular (false)</param>
        /// <returns>true on success, false on failure</returns>
        public bool SetSelectionItalic(bool italic)
        {
            return SetSelectionStyle(CFM_ITALIC, italic ? CFE_ITALIC : 0);
        }

        /// <summary>
        /// Sets the underlined style only for the selected part of the rich text box
        /// without modifying the other properties like font or size
        /// </summary>
        /// <param name="underlined">make selection underlined (true) or regular (false)</param>
        /// <returns>true on success, false on failure</returns>
        public bool SetSelectionUnderlined(bool underlined)
        {
            return SetSelectionStyle(CFM_UNDERLINE, underlined ? CFE_UNDERLINE : 0);
        }

        /// <summary>
        /// Set the style only for the selected part of the rich text box
        /// with the possibility to mask out some styles that are not to be modified
        /// </summary>
        /// <param name="mask">modify which styles?</param>
        /// <param name="effect">new values for the styles</param>
        /// <returns>true on success, false on failure</returns>
        private bool SetSelectionStyle(UInt32 mask, UInt32 effect)
        {
            CHARFORMAT cf = new CHARFORMAT();
            cf.cbSize = Marshal.SizeOf(cf);
            cf.dwMask = mask;
            cf.dwEffects = effect;

            IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
            Marshal.StructureToPtr(cf, lParam, false);

            int res = SendMessage(Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam);
            return (res == 0);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            this.SelectionFont = this.Font;
            this.SelectionBackColor = Color.White;
            this.BackColor = Color.White;
        }

        public void AppendText(string text, Color backColor)
        {
            Color formerSelectionColor = this.SelectionColor;

            SetSelectionColor(Color.White);
            SetSelectionBackColor(backColor);

            this.AppendText(text);

            SetSelectionColor(formerSelectionColor);
            SetSelectionBackColor(Color.White);
            this.DeselectAll();
        }

        private bool SetSelectionBackColor(Color color)
        {
            CHARFORMAT cf = new CHARFORMAT();
            cf.cbSize = Marshal.SizeOf(cf);
            cf.dwMask = CFM_BACKCOLOR;
            cf.crBackColor = ColorTranslator.ToWin32(color);

            IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
            Marshal.StructureToPtr(cf, lParam, false);

            int res = SendMessage(Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam);
            return (res == 0);
        }

        public bool SetSelectionColor(Color color)
        {
            CHARFORMAT cf = new CHARFORMAT();
            cf.cbSize = Marshal.SizeOf(cf);
            cf.dwMask = CFM_COLOR;
            cf.crTextColor = ColorTranslator.ToWin32(color);

            IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf));
            Marshal.StructureToPtr(cf, lParam, false);

            int res = SendMessage(Handle, EM_SETCHARFORMAT, SCF_SELECTION, lParam);
            return (res == 0);
        }
    }
}

