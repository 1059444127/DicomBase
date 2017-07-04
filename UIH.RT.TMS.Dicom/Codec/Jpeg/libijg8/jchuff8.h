////////////////////////////////////////////////////////////////////////
/// Copyright, (c) Shanghai United Imaging Healthcare Inc
/// All rights reserved. 
/// 
/// *@author: qiuyang.cao@united-imaging.com
///
/// @file: jchuff8.h
///
/// @brief:
///
///
/// @date: 2014/08/19
/////////////////////////////////////////////////////////////////////////
#pragma region License (non-CC)

// This source code contains the work of the Independent JPEG Group.
// Please see accompanying notice in code comments and/or readme file
// for the terms of distribution and use regarding this code.

#pragma endregion

/*
 * jchuff.h
 *
 * Copyright (C) 1991-1997, Thomas G. Lane.
 * This file is part of the Independent JPEG Group's software.
 * For conditions of distribution and use, see the accompanying README file.
 *
 * This file contains declarations for Huffman entropy encoding routines
 * that are shared between the sequential encoder (jchuff.c) and the
 * progressive encoder (jcphuff.c).  No other modules need to see these.
 */

/* The legal range of a DCT coefficient is
 *  -1024 .. +1023  for 8-bit data;
 * -16384 .. +16383 for 12-bit data.
 * Hence the magnitude should always fit in 10 or 14 bits respectively.
 */

#if BITS_IN_JSAMPLE == 8
#define MAX_COEF_BITS 10
#else
#define MAX_COEF_BITS 14
#endif

/* The legal range of a spatial difference is
 * -32767 .. +32768.
 * Hence the magnitude should always fit in 16 bits.
 */

#define MAX_DIFF_BITS 16

/* Derived data constructed for each Huffman table */

typedef struct {
  unsigned int ehufco[256];	/* code for each symbol */
  char ehufsi[256];		/* length of code for each symbol */
  /* If no code has been allocated for a symbol S, ehufsi[S] contains 0 */
} c_derived_tbl;

/* Short forms of external names for systems with brain-damaged linkers. */

#ifdef NEED_SHORT_EXTERNAL_NAMES
#define jpeg_make_c_derived_tbl		jpeg8_make_c_derived_tbl
#define jpeg_gen_optimal_table		jpeg8_gen_optimal_table
#endif /* NEED_SHORT_EXTERNAL_NAMES */

/* Expand a Huffman table definition into the derived format */
EXTERN(void) jpeg_make_c_derived_tbl
	JPP((j_compress_ptr cinfo, boolean isDC, int tblno,
	     c_derived_tbl ** pdtbl));

/* Generate an optimal table definition given the specified counts */
EXTERN(void) jpeg_gen_optimal_table
	JPP((j_compress_ptr cinfo, JHUFF_TBL * htbl, long freq[]));
