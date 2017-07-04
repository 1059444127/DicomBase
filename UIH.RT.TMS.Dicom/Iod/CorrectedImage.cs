/////////////////////////////////////////////////////////////////////////
//// Copyright, (c) Shanghai United Imaging Healthcare Inc
//// All rights reserved. 
//// 
//// author: qiuyang.cao@united-imaging.com
////
//// File: CorrectedImage.cs
////
//// Summary:
////
////
//// Date: 2014/08/18
//////////////////////////////////////////////////////////////////////////
#region License

// Copyright (c) 2011 - 2013, United-Imaging Inc.
// All rights reserved.
// http://www.united-imaging.com

#endregion

using System.Collections.Generic;

namespace UIH.RT.TMS.Dicom.Iod
{
	/// <summary>
	/// Defined terms for the <see cref="UIH.RT.TMS.Dicom.DicomTags.CorrectedImage"/> attribute 
	/// </summary>
	/// <remarks>As defined in the DICOM Standard 2011, Part 3, Section C.8.9.1 (Table C.8-60)</remarks>
	public struct CorrectedImage
	{
		/// <summary>
		/// Represents the empty value.
		/// </summary>
		public static readonly CorrectedImage Empty = new CorrectedImage();

		public static readonly CorrectedImage Decy = new CorrectedImage("DECY", "decay corrected");
		public static readonly CorrectedImage Attn = new CorrectedImage("ATTN", "attenuation corrected");
		public static readonly CorrectedImage Scat = new CorrectedImage("SCAT", "scatter corrected");
		public static readonly CorrectedImage DTim = new CorrectedImage("DTIM", "dead time corrected");
		public static readonly CorrectedImage Motn = new CorrectedImage("MOTN", "gantry motion corrected (e.g. wobble, clamshell)");
		public static readonly CorrectedImage PMot = new CorrectedImage("PMOT", "patient motion corrected");
		public static readonly CorrectedImage Cln = new CorrectedImage("CLN", "count loss normalization (correction for count loss in gated Time Slots)");
		public static readonly CorrectedImage Ran = new CorrectedImage("RAN", "randoms corrected");
		public static readonly CorrectedImage Radl = new CorrectedImage("RADL", "non-uniform radial sampling corrected");
		public static readonly CorrectedImage DCal = new CorrectedImage("DCAL", "sensitivity calibrated using dose calibrator");
		public static readonly CorrectedImage Norm = new CorrectedImage("NORM", "detector normalization");

		/// <summary>
		/// Enumeration of defined terms.
		/// </summary>
		public static IEnumerable<CorrectedImage> DefinedTerms
		{
			get
			{
				yield return Decy;
				yield return Attn;
				yield return Scat;
				yield return DTim;
				yield return Motn;
				yield return PMot;
				yield return Cln;
				yield return Ran;
				yield return Radl;
				yield return DCal;
				yield return Norm;
			}
		}

		private readonly string _code;
		private readonly string _description;

		/// <summary>
		/// Initializes a standard defined term.
		/// </summary>
		private CorrectedImage(string code, string description)
		{
			_code = code;
			_description = description;
		}

		/// <summary>
		/// Initializes a defined term.
		/// </summary>
		/// <param name="code"></param>
		public CorrectedImage(string code)
		{
			_description = _code = (code ?? string.Empty).ToUpperInvariant();
		}

		/// <summary>
		/// Gets the value of the defined term.
		/// </summary>
		public string Code
		{
			get { return _code ?? string.Empty; }
		}

		/// <summary>
		/// Gets a textual description of the defined term.
		/// </summary>
		public string Description
		{
			get { return _description ?? string.Empty; }
		}

		/// <summary>
		/// Gets a value indicating whether or not this represents the empty value.
		/// </summary>
		public bool IsEmpty
		{
			get { return string.IsNullOrEmpty(_code); }
		}

		/// <summary>
		/// Checks whether or not <paramref name="obj"/> represents the same defined term.
		/// </summary>
		public override bool Equals(object obj)
		{
			return obj is CorrectedImage && Equals((CorrectedImage) obj);
		}

		/// <summary>
		/// Checks whether or not this defined term is the same as <paramref name="other"/>.
		/// </summary>
		public bool Equals(CorrectedImage other)
		{
			return Code == other.Code;
		}

		public override int GetHashCode()
		{
			return -0x0A4F34E4 ^ Code.GetHashCode();
		}

		public override string ToString()
		{
			return Code;
		}

		public static bool operator ==(CorrectedImage x, CorrectedImage y)
		{
			return Equals(x, y);
		}

		public static bool operator !=(CorrectedImage x, CorrectedImage y)
		{
			return !Equals(x, y);
		}

		public static implicit operator string(CorrectedImage correctedImage)
		{
			return correctedImage.ToString();
		}

		public static explicit operator CorrectedImage(string correctedImage)
		{
			return new CorrectedImage(correctedImage);
		}
	}
}
