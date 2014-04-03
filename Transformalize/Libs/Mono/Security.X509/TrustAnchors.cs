//
// TrustAnchors.cs: "Official" default Trust Anchors for Mono
//
// Author:
//	Sebastien Pouliot (spouliot@motus.com)
//
// (C) 2003 Motus Technologies Inc. (http://www.motus.com)
//

//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

namespace Transformalize.Libs.Mono.Security.X509 {

#if INSIDE_CORLIB
	internal
#else
	public 
#endif
	class TrustAnchors : ITrustAnchors {

		static byte[] msroot = { 
			0x30, 0x82, 0x04, 0x12, 0x30, 0x82, 0x02, 0xFA, 0xA0, 0x03, 0x02, 0x01, 
			0x02, 0x02, 0x0F, 0x00, 0xC1, 0x00, 0x8B, 0x3C, 0x3C, 0x88, 0x11, 0xD1, 
			0x3E, 0xF6, 0x63, 0xEC, 0xDF, 0x40, 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 
			0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x04, 0x05, 0x00, 0x30, 0x70, 0x31, 
			0x2B, 0x30, 0x29, 0x06, 0x03, 0x55, 0x04, 0x0B, 0x13, 0x22, 0x43, 0x6F, 
			0x70, 0x79, 0x72, 0x69, 0x67, 0x68, 0x74, 0x20, 0x28, 0x63, 0x29, 0x20, 
			0x31, 0x39, 0x39, 0x37, 0x20, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 
			0x66, 0x74, 0x20, 0x43, 0x6F, 0x72, 0x70, 0x2E, 0x31, 0x1E, 0x30, 0x1C, 
			0x06, 0x03, 0x55, 0x04, 0x0B, 0x13, 0x15, 0x4D, 0x69, 0x63, 0x72, 0x6F, 
			0x73, 0x6F, 0x66, 0x74, 0x20, 0x43, 0x6F, 0x72, 0x70, 0x6F, 0x72, 0x61, 
			0x74, 0x69, 0x6F, 0x6E, 0x31, 0x21, 0x30, 0x1F, 0x06, 0x03, 0x55, 0x04, 
			0x03, 0x13, 0x18, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 
			0x20, 0x52, 0x6F, 0x6F, 0x74, 0x20, 0x41, 0x75, 0x74, 0x68, 0x6F, 0x72, 
			0x69, 0x74, 0x79, 0x30, 0x1E, 0x17, 0x0D, 0x39, 0x37, 0x30, 0x31, 0x31, 
			0x30, 0x30, 0x37, 0x30, 0x30, 0x30, 0x30, 0x5A, 0x17, 0x0D, 0x32, 0x30, 
			0x31, 0x32, 0x33, 0x31, 0x30, 0x37, 0x30, 0x30, 0x30, 0x30, 0x5A, 0x30, 
			0x70, 0x31, 0x2B, 0x30, 0x29, 0x06, 0x03, 0x55, 0x04, 0x0B, 0x13, 0x22, 
			0x43, 0x6F, 0x70, 0x79, 0x72, 0x69, 0x67, 0x68, 0x74, 0x20, 0x28, 0x63, 
			0x29, 0x20, 0x31, 0x39, 0x39, 0x37, 0x20, 0x4D, 0x69, 0x63, 0x72, 0x6F, 
			0x73, 0x6F, 0x66, 0x74, 0x20, 0x43, 0x6F, 0x72, 0x70, 0x2E, 0x31, 0x1E, 
			0x30, 0x1C, 0x06, 0x03, 0x55, 0x04, 0x0B, 0x13, 0x15, 0x4D, 0x69, 0x63, 
			0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x20, 0x43, 0x6F, 0x72, 0x70, 0x6F, 
			0x72, 0x61, 0x74, 0x69, 0x6F, 0x6E, 0x31, 0x21, 0x30, 0x1F, 0x06, 0x03, 
			0x55, 0x04, 0x03, 0x13, 0x18, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 
			0x66, 0x74, 0x20, 0x52, 0x6F, 0x6F, 0x74, 0x20, 0x41, 0x75, 0x74, 0x68, 
			0x6F, 0x72, 0x69, 0x74, 0x79, 0x30, 0x82, 0x01, 0x22, 0x30, 0x0D, 0x06, 
			0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00, 
			0x03, 0x82, 0x01, 0x0F, 0x00, 0x30, 0x82, 0x01, 0x0A, 0x02, 0x82, 0x01, 
			0x01, 0x00, 0xA9, 0x02, 0xBD, 0xC1, 0x70, 0xE6, 0x3B, 0xF2, 0x4E, 0x1B, 
			0x28, 0x9F, 0x97, 0x78, 0x5E, 0x30, 0xEA, 0xA2, 0xA9, 0x8D, 0x25, 0x5F, 
			0xF8, 0xFE, 0x95, 0x4C, 0xA3, 0xB7, 0xFE, 0x9D, 0xA2, 0x20, 0x3E, 0x7C, 
			0x51, 0xA2, 0x9B, 0xA2, 0x8F, 0x60, 0x32, 0x6B, 0xD1, 0x42, 0x64, 0x79, 
			0xEE, 0xAC, 0x76, 0xC9, 0x54, 0xDA, 0xF2, 0xEB, 0x9C, 0x86, 0x1C, 0x8F, 
			0x9F, 0x84, 0x66, 0xB3, 0xC5, 0x6B, 0x7A, 0x62, 0x23, 0xD6, 0x1D, 0x3C, 
			0xDE, 0x0F, 0x01, 0x92, 0xE8, 0x96, 0xC4, 0xBF, 0x2D, 0x66, 0x9A, 0x9A, 
			0x68, 0x26, 0x99, 0xD0, 0x3A, 0x2C, 0xBF, 0x0C, 0xB5, 0x58, 0x26, 0xC1, 
			0x46, 0xE7, 0x0A, 0x3E, 0x38, 0x96, 0x2C, 0xA9, 0x28, 0x39, 0xA8, 0xEC, 
			0x49, 0x83, 0x42, 0xE3, 0x84, 0x0F, 0xBB, 0x9A, 0x6C, 0x55, 0x61, 0xAC, 
			0x82, 0x7C, 0xA1, 0x60, 0x2D, 0x77, 0x4C, 0xE9, 0x99, 0xB4, 0x64, 0x3B, 
			0x9A, 0x50, 0x1C, 0x31, 0x08, 0x24, 0x14, 0x9F, 0xA9, 0xE7, 0x91, 0x2B, 
			0x18, 0xE6, 0x3D, 0x98, 0x63, 0x14, 0x60, 0x58, 0x05, 0x65, 0x9F, 0x1D, 
			0x37, 0x52, 0x87, 0xF7, 0xA7, 0xEF, 0x94, 0x02, 0xC6, 0x1B, 0xD3, 0xBF, 
			0x55, 0x45, 0xB3, 0x89, 0x80, 0xBF, 0x3A, 0xEC, 0x54, 0x94, 0x4E, 0xAE, 
			0xFD, 0xA7, 0x7A, 0x6D, 0x74, 0x4E, 0xAF, 0x18, 0xCC, 0x96, 0x09, 0x28, 
			0x21, 0x00, 0x57, 0x90, 0x60, 0x69, 0x37, 0xBB, 0x4B, 0x12, 0x07, 0x3C, 
			0x56, 0xFF, 0x5B, 0xFB, 0xA4, 0x66, 0x0A, 0x08, 0xA6, 0xD2, 0x81, 0x56, 
			0x57, 0xEF, 0xB6, 0x3B, 0x5E, 0x16, 0x81, 0x77, 0x04, 0xDA, 0xF6, 0xBE, 
			0xAE, 0x80, 0x95, 0xFE, 0xB0, 0xCD, 0x7F, 0xD6, 0xA7, 0x1A, 0x72, 0x5C, 
			0x3C, 0xCA, 0xBC, 0xF0, 0x08, 0xA3, 0x22, 0x30, 0xB3, 0x06, 0x85, 0xC9, 
			0xB3, 0x20, 0x77, 0x13, 0x85, 0xDF, 0x02, 0x03, 0x01, 0x00, 0x01, 0xA3, 
			0x81, 0xA8, 0x30, 0x81, 0xA5, 0x30, 0x81, 0xA2, 0x06, 0x03, 0x55, 0x1D, 
			0x01, 0x04, 0x81, 0x9A, 0x30, 0x81, 0x97, 0x80, 0x10, 0x5B, 0xD0, 0x70, 
			0xEF, 0x69, 0x72, 0x9E, 0x23, 0x51, 0x7E, 0x14, 0xB2, 0x4D, 0x8E, 0xFF, 
			0xCB, 0xA1, 0x72, 0x30, 0x70, 0x31, 0x2B, 0x30, 0x29, 0x06, 0x03, 0x55, 
			0x04, 0x0B, 0x13, 0x22, 0x43, 0x6F, 0x70, 0x79, 0x72, 0x69, 0x67, 0x68, 
			0x74, 0x20, 0x28, 0x63, 0x29, 0x20, 0x31, 0x39, 0x39, 0x37, 0x20, 0x4D, 
			0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x20, 0x43, 0x6F, 0x72, 
			0x70, 0x2E, 0x31, 0x1E, 0x30, 0x1C, 0x06, 0x03, 0x55, 0x04, 0x0B, 0x13, 
			0x15, 0x4D, 0x69, 0x63, 0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x20, 0x43, 
			0x6F, 0x72, 0x70, 0x6F, 0x72, 0x61, 0x74, 0x69, 0x6F, 0x6E, 0x31, 0x21, 
			0x30, 0x1F, 0x06, 0x03, 0x55, 0x04, 0x03, 0x13, 0x18, 0x4D, 0x69, 0x63, 
			0x72, 0x6F, 0x73, 0x6F, 0x66, 0x74, 0x20, 0x52, 0x6F, 0x6F, 0x74, 0x20, 
			0x41, 0x75, 0x74, 0x68, 0x6F, 0x72, 0x69, 0x74, 0x79, 0x82, 0x0F, 0x00, 
			0xC1, 0x00, 0x8B, 0x3C, 0x3C, 0x88, 0x11, 0xD1, 0x3E, 0xF6, 0x63, 0xEC, 
			0xDF, 0x40, 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 
			0x01, 0x01, 0x04, 0x05, 0x00, 0x03, 0x82, 0x01, 0x01, 0x00, 0x95, 0xE8, 
			0x0B, 0xC0, 0x8D, 0xF3, 0x97, 0x18, 0x35, 0xED, 0xB8, 0x01, 0x24, 0xD8, 
			0x77, 0x11, 0xF3, 0x5C, 0x60, 0x32, 0x9F, 0x9E, 0x0B, 0xCB, 0x3E, 0x05, 
			0x91, 0x88, 0x8F, 0xC9, 0x3A, 0xE6, 0x21, 0xF2, 0xF0, 0x57, 0x93, 0x2C, 
			0xB5, 0xA0, 0x47, 0xC8, 0x62, 0xEF, 0xFC, 0xD7, 0xCC, 0x3B, 0x3B, 0x5A, 
			0xA9, 0x36, 0x54, 0x69, 0xFE, 0x24, 0x6D, 0x3F, 0xC9, 0xCC, 0xAA, 0xDE, 
			0x05, 0x7C, 0xDD, 0x31, 0x8D, 0x3D, 0x9F, 0x10, 0x70, 0x6A, 0xBB, 0xFE, 
			0x12, 0x4F, 0x18, 0x69, 0xC0, 0xFC, 0xD0, 0x43, 0xE3, 0x11, 0x5A, 0x20, 
			0x4F, 0xEA, 0x62, 0x7B, 0xAF, 0xAA, 0x19, 0xC8, 0x2B, 0x37, 0x25, 0x2D, 
			0xBE, 0x65, 0xA1, 0x12, 0x8A, 0x25, 0x0F, 0x63, 0xA3, 0xF7, 0x54, 0x1C, 
			0xF9, 0x21, 0xC9, 0xD6, 0x15, 0xF3, 0x52, 0xAC, 0x6E, 0x43, 0x32, 0x07, 
			0xFD, 0x82, 0x17, 0xF8, 0xE5, 0x67, 0x6C, 0x0D, 0x51, 0xF6, 0xBD, 0xF1, 
			0x52, 0xC7, 0xBD, 0xE7, 0xC4, 0x30, 0xFC, 0x20, 0x31, 0x09, 0x88, 0x1D, 
			0x95, 0x29, 0x1A, 0x4D, 0xD5, 0x1D, 0x02, 0xA5, 0xF1, 0x80, 0xE0, 0x03, 
			0xB4, 0x5B, 0xF4, 0xB1, 0xDD, 0xC8, 0x57, 0xEE, 0x65, 0x49, 0xC7, 0x52, 
			0x54, 0xB6, 0xB4, 0x03, 0x28, 0x12, 0xFF, 0x90, 0xD6, 0xF0, 0x08, 0x8F, 
			0x7E, 0xB8, 0x97, 0xC5, 0xAB, 0x37, 0x2C, 0xE4, 0x7A, 0xE4, 0xA8, 0x77, 
			0xE3, 0x76, 0xA0, 0x00, 0xD0, 0x6A, 0x3F, 0xC1, 0xD2, 0x36, 0x8A, 0xE0, 
			0x41, 0x12, 0xA8, 0x35, 0x6A, 0x1B, 0x6A, 0xDB, 0x35, 0xE1, 0xD4, 0x1C, 
			0x04, 0xE4, 0xA8, 0x45, 0x04, 0xC8, 0x5A, 0x33, 0x38, 0x6E, 0x4D, 0x1C, 
			0x0D, 0x62, 0xB7, 0x0A, 0xA2, 0x8C, 0xD3, 0xD5, 0x54, 0x3F, 0x46, 0xCD, 
			0x1C, 0x55, 0xA6, 0x70, 0xDB, 0x12, 0x3A, 0x87, 0x93, 0x75, 0x9F, 0xA7, 
			0xD2, 0xA0 };

		static byte[] verisign = { 
			0x30, 0x82, 0x02, 0x40, 0x30, 0x82, 0x01, 0xA9, 0x02, 0x10, 0x03, 0xC7, 
			0x8F, 0x37, 0xDB, 0x92, 0x28, 0xDF, 0x3C, 0xBB, 0x1A, 0xAD, 0x82, 0xFA, 
			0x67, 0x10, 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 
			0x01, 0x01, 0x02, 0x05, 0x00, 0x30, 0x61, 0x31, 0x11, 0x30, 0x0F, 0x06, 
			0x03, 0x55, 0x04, 0x07, 0x13, 0x08, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6E, 
			0x65, 0x74, 0x31, 0x17, 0x30, 0x15, 0x06, 0x03, 0x55, 0x04, 0x0A, 0x13, 
			0x0E, 0x56, 0x65, 0x72, 0x69, 0x53, 0x69, 0x67, 0x6E, 0x2C, 0x20, 0x49, 
			0x6E, 0x63, 0x2E, 0x31, 0x33, 0x30, 0x31, 0x06, 0x03, 0x55, 0x04, 0x0B, 
			0x13, 0x2A, 0x56, 0x65, 0x72, 0x69, 0x53, 0x69, 0x67, 0x6E, 0x20, 0x43, 
			0x6F, 0x6D, 0x6D, 0x65, 0x72, 0x63, 0x69, 0x61, 0x6C, 0x20, 0x53, 0x6F, 
			0x66, 0x74, 0x77, 0x61, 0x72, 0x65, 0x20, 0x50, 0x75, 0x62, 0x6C, 0x69, 
			0x73, 0x68, 0x65, 0x72, 0x73, 0x20, 0x43, 0x41, 0x30, 0x1E, 0x17, 0x0D, 
			0x39, 0x36, 0x30, 0x34, 0x30, 0x39, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 
			0x5A, 0x17, 0x0D, 0x30, 0x34, 0x30, 0x31, 0x30, 0x37, 0x32, 0x33, 0x35, 
			0x39, 0x35, 0x39, 0x5A, 0x30, 0x61, 0x31, 0x11, 0x30, 0x0F, 0x06, 0x03, 
			0x55, 0x04, 0x07, 0x13, 0x08, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6E, 0x65, 
			0x74, 0x31, 0x17, 0x30, 0x15, 0x06, 0x03, 0x55, 0x04, 0x0A, 0x13, 0x0E, 
			0x56, 0x65, 0x72, 0x69, 0x53, 0x69, 0x67, 0x6E, 0x2C, 0x20, 0x49, 0x6E, 
			0x63, 0x2E, 0x31, 0x33, 0x30, 0x31, 0x06, 0x03, 0x55, 0x04, 0x0B, 0x13, 
			0x2A, 0x56, 0x65, 0x72, 0x69, 0x53, 0x69, 0x67, 0x6E, 0x20, 0x43, 0x6F, 
			0x6D, 0x6D, 0x65, 0x72, 0x63, 0x69, 0x61, 0x6C, 0x20, 0x53, 0x6F, 0x66, 
			0x74, 0x77, 0x61, 0x72, 0x65, 0x20, 0x50, 0x75, 0x62, 0x6C, 0x69, 0x73, 
			0x68, 0x65, 0x72, 0x73, 0x20, 0x43, 0x41, 0x30, 0x81, 0x9F, 0x30, 0x0D, 
			0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 
			0x00, 0x03, 0x81, 0x8D, 0x00, 0x30, 0x81, 0x89, 0x02, 0x81, 0x81, 0x00, 
			0xC3, 0xD3, 0x69, 0x65, 0x52, 0x01, 0x94, 0x54, 0xAB, 0x28, 0xC6, 0x62, 
			0x18, 0xB3, 0x54, 0x55, 0xC5, 0x44, 0x87, 0x45, 0x4A, 0x3B, 0xC2, 0x7E, 
			0xD8, 0xD3, 0xD7, 0xC8, 0x80, 0x86, 0x8D, 0xD8, 0x0C, 0xF1, 0x16, 0x9C, 
			0xCC, 0x6B, 0xA9, 0x29, 0xB2, 0x8F, 0x76, 0x73, 0x92, 0xC8, 0xC5, 0x62, 
			0xA6, 0x3C, 0xED, 0x1E, 0x05, 0x75, 0xF0, 0x13, 0x00, 0x6C, 0x14, 0x4D, 
			0xD4, 0x98, 0x90, 0x07, 0xBE, 0x69, 0x73, 0x81, 0xB8, 0x62, 0x4E, 0x31, 
			0x1E, 0xD1, 0xFC, 0xC9, 0x0C, 0xEB, 0x7D, 0x90, 0xBF, 0xAE, 0xB4, 0x47, 
			0x51, 0xEC, 0x6F, 0xCE, 0x64, 0x35, 0x02, 0xD6, 0x7D, 0x67, 0x05, 0x77, 
			0xE2, 0x8F, 0xD9, 0x51, 0xD7, 0xFB, 0x97, 0x19, 0xBC, 0x3E, 0xD7, 0x77, 
			0x81, 0xC6, 0x43, 0xDD, 0xF2, 0xDD, 0xDF, 0xCA, 0xA3, 0x83, 0x8B, 0xCB, 
			0x41, 0xC1, 0x3D, 0x22, 0x48, 0x48, 0xA6, 0x19, 0x02, 0x03, 0x01, 0x00, 
			0x01, 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 
			0x01, 0x02, 0x05, 0x00, 0x03, 0x81, 0x81, 0x00, 0xB5, 0xBC, 0xB0, 0x75, 
			0x6A, 0x89, 0xA2, 0x86, 0xBD, 0x64, 0x78, 0xC3, 0xA7, 0x32, 0x75, 0x72, 
			0x11, 0xAA, 0x26, 0x02, 0x17, 0x60, 0x30, 0x4C, 0xE3, 0x48, 0x34, 0x19, 
			0xB9, 0x52, 0x4A, 0x51, 0x18, 0x80, 0xFE, 0x53, 0x2D, 0x7B, 0xD5, 0x31, 
			0x8C, 0xC5, 0x65, 0x99, 0x41, 0x41, 0x2F, 0xF2, 0xAE, 0x63, 0x7A, 0xE8, 
			0x73, 0x99, 0x15, 0x90, 0x1A, 0x1F, 0x7A, 0x8B, 0x41, 0xD0, 0x8E, 0x3A, 
			0xD0, 0xCD, 0x38, 0x34, 0x44, 0xD0, 0x75, 0xF8, 0xEA, 0x71, 0xC4, 0x81, 
			0x19, 0x38, 0x17, 0x35, 0x4A, 0xAE, 0xC5, 0x3E, 0x32, 0xE6, 0x21, 0xB8, 
			0x05, 0xC0, 0x93, 0xE1, 0xC7, 0x38, 0x5C, 0xD8, 0xF7, 0x93, 0x38, 0x64, 
			0x90, 0xED, 0x54, 0xCE, 0xCA, 0xD3, 0xD3, 0xD0, 0x5F, 0xEF, 0x04, 0x9B, 
			0xDE, 0x02, 0x82, 0xDD, 0x88, 0x29, 0xB1, 0xC3, 0x4F, 0xA5, 0xCD, 0x71, 
			0x64, 0x31, 0x3C, 0x3C };

		static byte[] verisign_ts_root = { 
			0x30, 0x82, 0x02, 0xBC, 0x30, 0x82, 0x02, 0x25, 0x02, 0x10, 0x4A, 0x19, 
			0xD2, 0x38, 0x8C, 0x82, 0x59, 0x1C, 0xA5, 0x5D, 0x73, 0x5F, 0x15, 0x5D, 
			0xDC, 0xA3, 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 
			0x01, 0x01, 0x04, 0x05, 0x00, 0x30, 0x81, 0x9E, 0x31, 0x1F, 0x30, 0x1D, 
			0x06, 0x03, 0x55, 0x04, 0x0A, 0x13, 0x16, 0x56, 0x65, 0x72, 0x69, 0x53, 
			0x69, 0x67, 0x6E, 0x20, 0x54, 0x72, 0x75, 0x73, 0x74, 0x20, 0x4E, 0x65, 
			0x74, 0x77, 0x6F, 0x72, 0x6B, 0x31, 0x17, 0x30, 0x15, 0x06, 0x03, 0x55, 
			0x04, 0x0B, 0x13, 0x0E, 0x56, 0x65, 0x72, 0x69, 0x53, 0x69, 0x67, 0x6E, 
			0x2C, 0x20, 0x49, 0x6E, 0x63, 0x2E, 0x31, 0x2C, 0x30, 0x2A, 0x06, 0x03, 
			0x55, 0x04, 0x0B, 0x13, 0x23, 0x56, 0x65, 0x72, 0x69, 0x53, 0x69, 0x67, 
			0x6E, 0x20, 0x54, 0x69, 0x6D, 0x65, 0x20, 0x53, 0x74, 0x61, 0x6D, 0x70, 
			0x69, 0x6E, 0x67, 0x20, 0x53, 0x65, 0x72, 0x76, 0x69, 0x63, 0x65, 0x20, 
			0x52, 0x6F, 0x6F, 0x74, 0x31, 0x34, 0x30, 0x32, 0x06, 0x03, 0x55, 0x04, 
			0x0B, 0x13, 0x2B, 0x4E, 0x4F, 0x20, 0x4C, 0x49, 0x41, 0x42, 0x49, 0x4C, 
			0x49, 0x54, 0x59, 0x20, 0x41, 0x43, 0x43, 0x45, 0x50, 0x54, 0x45, 0x44, 
			0x2C, 0x20, 0x28, 0x63, 0x29, 0x39, 0x37, 0x20, 0x56, 0x65, 0x72, 0x69, 
			0x53, 0x69, 0x67, 0x6E, 0x2C, 0x20, 0x49, 0x6E, 0x63, 0x2E, 0x30, 0x1E, 
			0x17, 0x0D, 0x39, 0x37, 0x30, 0x35, 0x31, 0x32, 0x30, 0x30, 0x30, 0x30, 
			0x30, 0x30, 0x5A, 0x17, 0x0D, 0x30, 0x34, 0x30, 0x31, 0x30, 0x37, 0x32, 
			0x33, 0x35, 0x39, 0x35, 0x39, 0x5A, 0x30, 0x81, 0x9E, 0x31, 0x1F, 0x30, 
			0x1D, 0x06, 0x03, 0x55, 0x04, 0x0A, 0x13, 0x16, 0x56, 0x65, 0x72, 0x69, 
			0x53, 0x69, 0x67, 0x6E, 0x20, 0x54, 0x72, 0x75, 0x73, 0x74, 0x20, 0x4E, 
			0x65, 0x74, 0x77, 0x6F, 0x72, 0x6B, 0x31, 0x17, 0x30, 0x15, 0x06, 0x03, 
			0x55, 0x04, 0x0B, 0x13, 0x0E, 0x56, 0x65, 0x72, 0x69, 0x53, 0x69, 0x67, 
			0x6E, 0x2C, 0x20, 0x49, 0x6E, 0x63, 0x2E, 0x31, 0x2C, 0x30, 0x2A, 0x06, 
			0x03, 0x55, 0x04, 0x0B, 0x13, 0x23, 0x56, 0x65, 0x72, 0x69, 0x53, 0x69, 
			0x67, 0x6E, 0x20, 0x54, 0x69, 0x6D, 0x65, 0x20, 0x53, 0x74, 0x61, 0x6D, 
			0x70, 0x69, 0x6E, 0x67, 0x20, 0x53, 0x65, 0x72, 0x76, 0x69, 0x63, 0x65, 
			0x20, 0x52, 0x6F, 0x6F, 0x74, 0x31, 0x34, 0x30, 0x32, 0x06, 0x03, 0x55, 
			0x04, 0x0B, 0x13, 0x2B, 0x4E, 0x4F, 0x20, 0x4C, 0x49, 0x41, 0x42, 0x49, 
			0x4C, 0x49, 0x54, 0x59, 0x20, 0x41, 0x43, 0x43, 0x45, 0x50, 0x54, 0x45, 
			0x44, 0x2C, 0x20, 0x28, 0x63, 0x29, 0x39, 0x37, 0x20, 0x56, 0x65, 0x72, 
			0x69, 0x53, 0x69, 0x67, 0x6E, 0x2C, 0x20, 0x49, 0x6E, 0x63, 0x2E, 0x30, 
			0x81, 0x9F, 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 
			0x01, 0x01, 0x01, 0x05, 0x00, 0x03, 0x81, 0x8D, 0x00, 0x30, 0x81, 0x89, 
			0x02, 0x81, 0x81, 0x00, 0xD3, 0x2E, 0x20, 0xF0, 0x68, 0x7C, 0x2C, 0x2D, 
			0x2E, 0x81, 0x1C, 0xB1, 0x06, 0xB2, 0xA7, 0x0B, 0xB7, 0x11, 0x0D, 0x57, 
			0xDA, 0x53, 0xD8, 0x75, 0xE3, 0xC9, 0x33, 0x2A, 0xB2, 0xD4, 0xF6, 0x09, 
			0x5B, 0x34, 0xF3, 0xE9, 0x90, 0xFE, 0x09, 0x0C, 0xD0, 0xDB, 0x1B, 0x5A, 
			0xB9, 0xCD, 0xE7, 0xF6, 0x88, 0xB1, 0x9D, 0xC0, 0x87, 0x25, 0xEB, 0x7D, 
			0x58, 0x10, 0x73, 0x6A, 0x78, 0xCB, 0x71, 0x15, 0xFD, 0xC6, 0x58, 0xF6, 
			0x29, 0xAB, 0x58, 0x5E, 0x96, 0x04, 0xFD, 0x2D, 0x62, 0x11, 0x58, 0x81, 
			0x1C, 0xCA, 0x71, 0x94, 0xD5, 0x22, 0x58, 0x2F, 0xD5, 0xCC, 0x14, 0x05, 
			0x84, 0x36, 0xBA, 0x94, 0xAA, 0xB4, 0x4D, 0x4A, 0xE9, 0xEE, 0x3B, 0x22, 
			0xAD, 0x56, 0x99, 0x7E, 0x21, 0x9C, 0x6C, 0x86, 0xC0, 0x4A, 0x47, 0x97, 
			0x6A, 0xB4, 0xA6, 0x36, 0xD5, 0xFC, 0x09, 0x2D, 0xD3, 0xB4, 0x39, 0x9B, 
			0x02, 0x03, 0x01, 0x00, 0x01, 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 
			0x86, 0xF7, 0x0D, 0x01, 0x01, 0x04, 0x05, 0x00, 0x03, 0x81, 0x81, 0x00, 
			0x61, 0x55, 0x0E, 0x3E, 0x7B, 0xC7, 0x92, 0x12, 0x7E, 0x11, 0x10, 0x8E, 
			0x22, 0xCC, 0xD4, 0xB3, 0x13, 0x2B, 0x5B, 0xE8, 0x44, 0xE4, 0x0B, 0x78, 
			0x9E, 0xA4, 0x7E, 0xF3, 0xA7, 0x07, 0x72, 0x1E, 0xE2, 0x59, 0xEF, 0xCC, 
			0x84, 0xE3, 0x89, 0x94, 0x4C, 0xDB, 0x4E, 0x61, 0xEF, 0xB3, 0xA4, 0xFB, 
			0x46, 0x3D, 0x50, 0x34, 0x0B, 0x9F, 0x70, 0x56, 0xF6, 0x8E, 0x2A, 0x7F, 
			0x17, 0xCE, 0xE5, 0x63, 0xBF, 0x79, 0x69, 0x07, 0x73, 0x2E, 0xB0, 0x95, 
			0x28, 0x8A, 0xF5, 0xED, 0xAA, 0xA9, 0xD2, 0x5D, 0xCD, 0x0A, 0xCA, 0x10, 
			0x09, 0x8F, 0xCE, 0xB3, 0xAF, 0x28, 0x96, 0xC4, 0x79, 0x29, 0x84, 0x92, 
			0xDC, 0xFF, 0xBA, 0x67, 0x42, 0x48, 0xA6, 0x90, 0x10, 0xE4, 0xBF, 0x61, 
			0xF8, 0x9C, 0x53, 0xE5, 0x93, 0xD1, 0x73, 0x3F, 0xF8, 0xFD, 0x9D, 0x4F, 
			0x84, 0xAC, 0x55, 0xD1, 0xFD, 0x11, 0x63, 0x63 };

		// old verisign code signing certificate (96-99) using MD2
		// still valid because of the timestamps
		static byte[] oldverisign = { 
			0x30, 0x82, 0x02, 0x35, 0x30, 0x82, 0x01, 0x9E, 0x02, 0x05, 0x02, 0xB4, 
			0x00, 0x00, 0x01, 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 
			0x0D, 0x01, 0x01, 0x02, 0x05, 0x00, 0x30, 0x61, 0x31, 0x11, 0x30, 0x0F, 
			0x06, 0x03, 0x55, 0x04, 0x07, 0x13, 0x08, 0x49, 0x6E, 0x74, 0x65, 0x72, 
			0x6E, 0x65, 0x74, 0x31, 0x17, 0x30, 0x15, 0x06, 0x03, 0x55, 0x04, 0x0A, 
			0x13, 0x0E, 0x56, 0x65, 0x72, 0x69, 0x53, 0x69, 0x67, 0x6E, 0x2C, 0x20, 
			0x49, 0x6E, 0x63, 0x2E, 0x31, 0x33, 0x30, 0x31, 0x06, 0x03, 0x55, 0x04, 
			0x0B, 0x13, 0x2A, 0x56, 0x65, 0x72, 0x69, 0x53, 0x69, 0x67, 0x6E, 0x20, 
			0x43, 0x6F, 0x6D, 0x6D, 0x65, 0x72, 0x63, 0x69, 0x61, 0x6C, 0x20, 0x53, 
			0x6F, 0x66, 0x74, 0x77, 0x61, 0x72, 0x65, 0x20, 0x50, 0x75, 0x62, 0x6C, 
			0x69, 0x73, 0x68, 0x65, 0x72, 0x73, 0x20, 0x43, 0x41, 0x30, 0x1E, 0x17, 
			0x0D, 0x39, 0x36, 0x30, 0x34, 0x30, 0x39, 0x30, 0x39, 0x33, 0x35, 0x35, 
			0x39, 0x5A, 0x17, 0x0D, 0x39, 0x39, 0x31, 0x32, 0x33, 0x31, 0x30, 0x39, 
			0x33, 0x35, 0x35, 0x38, 0x5A, 0x30, 0x61, 0x31, 0x11, 0x30, 0x0F, 0x06, 
			0x03, 0x55, 0x04, 0x07, 0x13, 0x08, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6E, 
			0x65, 0x74, 0x31, 0x17, 0x30, 0x15, 0x06, 0x03, 0x55, 0x04, 0x0A, 0x13, 
			0x0E, 0x56, 0x65, 0x72, 0x69, 0x53, 0x69, 0x67, 0x6E, 0x2C, 0x20, 0x49, 
			0x6E, 0x63, 0x2E, 0x31, 0x33, 0x30, 0x31, 0x06, 0x03, 0x55, 0x04, 0x0B, 
			0x13, 0x2A, 0x56, 0x65, 0x72, 0x69, 0x53, 0x69, 0x67, 0x6E, 0x20, 0x43, 
			0x6F, 0x6D, 0x6D, 0x65, 0x72, 0x63, 0x69, 0x61, 0x6C, 0x20, 0x53, 0x6F, 
			0x66, 0x74, 0x77, 0x61, 0x72, 0x65, 0x20, 0x50, 0x75, 0x62, 0x6C, 0x69, 
			0x73, 0x68, 0x65, 0x72, 0x73, 0x20, 0x43, 0x41, 0x30, 0x81, 0x9F, 0x30, 
			0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 
			0x05, 0x00, 0x03, 0x81, 0x8D, 0x00, 0x30, 0x81, 0x89, 0x02, 0x81, 0x81, 
			0x00, 0xC3, 0xD3, 0x69, 0x65, 0x52, 0x01, 0x94, 0x54, 0xAB, 0x28, 0xC6, 
			0x62, 0x18, 0xB3, 0x54, 0x55, 0xC5, 0x44, 0x87, 0x45, 0x4A, 0x3B, 0xC2, 
			0x7E, 0xD8, 0xD3, 0xD7, 0xC8, 0x80, 0x86, 0x8D, 0xD8, 0x0C, 0xF1, 0x16, 
			0x9C, 0xCC, 0x6B, 0xA9, 0x29, 0xB2, 0x8F, 0x76, 0x73, 0x92, 0xC8, 0xC5, 
			0x62, 0xA6, 0x3C, 0xED, 0x1E, 0x05, 0x75, 0xF0, 0x13, 0x00, 0x6C, 0x14, 
			0x4D, 0xD4, 0x98, 0x90, 0x07, 0xBE, 0x69, 0x73, 0x81, 0xB8, 0x62, 0x4E, 
			0x31, 0x1E, 0xD1, 0xFC, 0xC9, 0x0C, 0xEB, 0x7D, 0x90, 0xBF, 0xAE, 0xB4, 
			0x47, 0x51, 0xEC, 0x6F, 0xCE, 0x64, 0x35, 0x02, 0xD6, 0x7D, 0x67, 0x05, 
			0x77, 0xE2, 0x8F, 0xD9, 0x51, 0xD7, 0xFB, 0x97, 0x19, 0xBC, 0x3E, 0xD7, 
			0x77, 0x81, 0xC6, 0x43, 0xDD, 0xF2, 0xDD, 0xDF, 0xCA, 0xA3, 0x83, 0x8B, 
			0xCB, 0x41, 0xC1, 0x3D, 0x22, 0x48, 0x48, 0xA6, 0x19, 0x02, 0x03, 0x01, 
			0x00, 0x01, 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 
			0x01, 0x01, 0x02, 0x05, 0x00, 0x03, 0x81, 0x81, 0x00, 0x31, 0xBB, 0x30, 
			0xC5, 0x6F, 0xA7, 0xBE, 0x23, 0x26, 0x6D, 0xA5, 0x99, 0x76, 0x68, 0xC5, 
			0x2A, 0x03, 0x28, 0x4B, 0xF3, 0x89, 0xB0, 0x99, 0x03, 0x32, 0x5B, 0x94, 
			0xA1, 0x7B, 0xC1, 0xC8, 0x19, 0xD7, 0xF4, 0x95, 0x6C, 0xAC, 0x73, 0x24, 
			0x0A, 0xCB, 0x44, 0x05, 0x7D, 0x78, 0xEE, 0xFA, 0xF6, 0xA7, 0x9F, 0x87, 
			0xA4, 0x7F, 0xE8, 0xF3, 0x4B, 0x4F, 0x32, 0x30, 0x30, 0x15, 0x08, 0x17, 
			0x01, 0xB2, 0x80, 0xFC, 0xA1, 0xD9, 0x24, 0x87, 0xA5, 0x00, 0x5F, 0xCD, 
			0xDD, 0x29, 0xC8, 0xA1, 0xA5, 0xCA, 0x58, 0x75, 0x39, 0x60, 0x45, 0x1F, 
			0xDE, 0x8D, 0xD6, 0x57, 0x08, 0xD3, 0xC0, 0x1B, 0x81, 0xC2, 0xD9, 0xE2, 
			0x00, 0x8C, 0xEC, 0x0A, 0x91, 0x02, 0xC6, 0x9D, 0x36, 0x74, 0x9A, 0x83, 
			0x6B, 0xEF, 0x7C, 0x8C, 0xD2, 0xA5, 0x2A, 0x6A, 0xC9, 0x7E, 0xDB, 0xA9, 
			0xBD, 0x2B, 0x22, 0xFF, 0x1C };

		static byte[] thawte = { 
			0x30, 0x82, 0x03, 0x13, 0x30, 0x82, 0x02, 0x7C, 0xA0, 0x03, 0x02, 0x01, 
			0x02, 0x02, 0x01, 0x01, 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 
			0xF7, 0x0D, 0x01, 0x01, 0x04, 0x05, 0x00, 0x30, 0x81, 0xC4, 0x31, 0x0B, 
			0x30, 0x09, 0x06, 0x03, 0x55, 0x04, 0x06, 0x13, 0x02, 0x5A, 0x41, 0x31, 
			0x15, 0x30, 0x13, 0x06, 0x03, 0x55, 0x04, 0x08, 0x13, 0x0C, 0x57, 0x65, 
			0x73, 0x74, 0x65, 0x72, 0x6E, 0x20, 0x43, 0x61, 0x70, 0x65, 0x31, 0x12, 
			0x30, 0x10, 0x06, 0x03, 0x55, 0x04, 0x07, 0x13, 0x09, 0x43, 0x61, 0x70, 
			0x65, 0x20, 0x54, 0x6F, 0x77, 0x6E, 0x31, 0x1D, 0x30, 0x1B, 0x06, 0x03, 
			0x55, 0x04, 0x0A, 0x13, 0x14, 0x54, 0x68, 0x61, 0x77, 0x74, 0x65, 0x20, 
			0x43, 0x6F, 0x6E, 0x73, 0x75, 0x6C, 0x74, 0x69, 0x6E, 0x67, 0x20, 0x63, 
			0x63, 0x31, 0x28, 0x30, 0x26, 0x06, 0x03, 0x55, 0x04, 0x0B, 0x13, 0x1F, 
			0x43, 0x65, 0x72, 0x74, 0x69, 0x66, 0x69, 0x63, 0x61, 0x74, 0x69, 0x6F, 
			0x6E, 0x20, 0x53, 0x65, 0x72, 0x76, 0x69, 0x63, 0x65, 0x73, 0x20, 0x44, 
			0x69, 0x76, 0x69, 0x73, 0x69, 0x6F, 0x6E, 0x31, 0x19, 0x30, 0x17, 0x06, 
			0x03, 0x55, 0x04, 0x03, 0x13, 0x10, 0x54, 0x68, 0x61, 0x77, 0x74, 0x65, 
			0x20, 0x53, 0x65, 0x72, 0x76, 0x65, 0x72, 0x20, 0x43, 0x41, 0x31, 0x26, 
			0x30, 0x24, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x09, 
			0x01, 0x16, 0x17, 0x73, 0x65, 0x72, 0x76, 0x65, 0x72, 0x2D, 0x63, 0x65, 
			0x72, 0x74, 0x73, 0x40, 0x74, 0x68, 0x61, 0x77, 0x74, 0x65, 0x2E, 0x63, 
			0x6F, 0x6D, 0x30, 0x1E, 0x17, 0x0D, 0x39, 0x36, 0x30, 0x38, 0x30, 0x31, 
			0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x5A, 0x17, 0x0D, 0x32, 0x30, 0x31, 
			0x32, 0x33, 0x31, 0x32, 0x33, 0x35, 0x39, 0x35, 0x39, 0x5A, 0x30, 0x81, 
			0xC4, 0x31, 0x0B, 0x30, 0x09, 0x06, 0x03, 0x55, 0x04, 0x06, 0x13, 0x02, 
			0x5A, 0x41, 0x31, 0x15, 0x30, 0x13, 0x06, 0x03, 0x55, 0x04, 0x08, 0x13, 
			0x0C, 0x57, 0x65, 0x73, 0x74, 0x65, 0x72, 0x6E, 0x20, 0x43, 0x61, 0x70, 
			0x65, 0x31, 0x12, 0x30, 0x10, 0x06, 0x03, 0x55, 0x04, 0x07, 0x13, 0x09, 
			0x43, 0x61, 0x70, 0x65, 0x20, 0x54, 0x6F, 0x77, 0x6E, 0x31, 0x1D, 0x30, 
			0x1B, 0x06, 0x03, 0x55, 0x04, 0x0A, 0x13, 0x14, 0x54, 0x68, 0x61, 0x77, 
			0x74, 0x65, 0x20, 0x43, 0x6F, 0x6E, 0x73, 0x75, 0x6C, 0x74, 0x69, 0x6E, 
			0x67, 0x20, 0x63, 0x63, 0x31, 0x28, 0x30, 0x26, 0x06, 0x03, 0x55, 0x04, 
			0x0B, 0x13, 0x1F, 0x43, 0x65, 0x72, 0x74, 0x69, 0x66, 0x69, 0x63, 0x61, 
			0x74, 0x69, 0x6F, 0x6E, 0x20, 0x53, 0x65, 0x72, 0x76, 0x69, 0x63, 0x65, 
			0x73, 0x20, 0x44, 0x69, 0x76, 0x69, 0x73, 0x69, 0x6F, 0x6E, 0x31, 0x19, 
			0x30, 0x17, 0x06, 0x03, 0x55, 0x04, 0x03, 0x13, 0x10, 0x54, 0x68, 0x61, 
			0x77, 0x74, 0x65, 0x20, 0x53, 0x65, 0x72, 0x76, 0x65, 0x72, 0x20, 0x43, 
			0x41, 0x31, 0x26, 0x30, 0x24, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 
			0x0D, 0x01, 0x09, 0x01, 0x16, 0x17, 0x73, 0x65, 0x72, 0x76, 0x65, 0x72, 
			0x2D, 0x63, 0x65, 0x72, 0x74, 0x73, 0x40, 0x74, 0x68, 0x61, 0x77, 0x74, 
			0x65, 0x2E, 0x63, 0x6F, 0x6D, 0x30, 0x81, 0x9F, 0x30, 0x0D, 0x06, 0x09, 
			0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00, 0x03, 
			0x81, 0x8D, 0x00, 0x30, 0x81, 0x89, 0x02, 0x81, 0x81, 0x00, 0xD3, 0xA4, 
			0x50, 0x6E, 0xC8, 0xFF, 0x56, 0x6B, 0xE6, 0xCF, 0x5D, 0xB6, 0xEA, 0x0C, 
			0x68, 0x75, 0x47, 0xA2, 0xAA, 0xC2, 0xDA, 0x84, 0x25, 0xFC, 0xA8, 0xF4, 
			0x47, 0x51, 0xDA, 0x85, 0xB5, 0x20, 0x74, 0x94, 0x86, 0x1E, 0x0F, 0x75, 
			0xC9, 0xE9, 0x08, 0x61, 0xF5, 0x06, 0x6D, 0x30, 0x6E, 0x15, 0x19, 0x02, 
			0xE9, 0x52, 0xC0, 0x62, 0xDB, 0x4D, 0x99, 0x9E, 0xE2, 0x6A, 0x0C, 0x44, 
			0x38, 0xCD, 0xFE, 0xBE, 0xE3, 0x64, 0x09, 0x70, 0xC5, 0xFE, 0xB1, 0x6B, 
			0x29, 0xB6, 0x2F, 0x49, 0xC8, 0x3B, 0xD4, 0x27, 0x04, 0x25, 0x10, 0x97, 
			0x2F, 0xE7, 0x90, 0x6D, 0xC0, 0x28, 0x42, 0x99, 0xD7, 0x4C, 0x43, 0xDE, 
			0xC3, 0xF5, 0x21, 0x6D, 0x54, 0x9F, 0x5D, 0xC3, 0x58, 0xE1, 0xC0, 0xE4, 
			0xD9, 0x5B, 0xB0, 0xB8, 0xDC, 0xB4, 0x7B, 0xDF, 0x36, 0x3A, 0xC2, 0xB5, 
			0x66, 0x22, 0x12, 0xD6, 0x87, 0x0D, 0x02, 0x03, 0x01, 0x00, 0x01, 0xA3, 
			0x13, 0x30, 0x11, 0x30, 0x0F, 0x06, 0x03, 0x55, 0x1D, 0x13, 0x01, 0x01, 
			0xFF, 0x04, 0x05, 0x30, 0x03, 0x01, 0x01, 0xFF, 0x30, 0x0D, 0x06, 0x09, 
			0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x04, 0x05, 0x00, 0x03, 
			0x81, 0x81, 0x00, 0x07, 0xFA, 0x4C, 0x69, 0x5C, 0xFB, 0x95, 0xCC, 0x46, 
			0xEE, 0x85, 0x83, 0x4D, 0x21, 0x30, 0x8E, 0xCA, 0xD9, 0xA8, 0x6F, 0x49, 
			0x1A, 0xE6, 0xDA, 0x51, 0xE3, 0x60, 0x70, 0x6C, 0x84, 0x61, 0x11, 0xA1, 
			0x1A, 0xC8, 0x48, 0x3E, 0x59, 0x43, 0x7D, 0x4F, 0x95, 0x3D, 0xA1, 0x8B, 
			0xB7, 0x0B, 0x62, 0x98, 0x7A, 0x75, 0x8A, 0xDD, 0x88, 0x4E, 0x4E, 0x9E, 
			0x40, 0xDB, 0xA8, 0xCC, 0x32, 0x74, 0xB9, 0x6F, 0x0D, 0xC6, 0xE3, 0xB3, 
			0x44, 0x0B, 0xD9, 0x8A, 0x6F, 0x9A, 0x29, 0x9B, 0x99, 0x18, 0x28, 0x3B, 
			0xD1, 0xE3, 0x40, 0x28, 0x9A, 0x5A, 0x3C, 0xD5, 0xB5, 0xE7, 0x20, 0x1B, 
			0x8B, 0xCA, 0xA4, 0xAB, 0x8D, 0xE9, 0x51, 0xD9, 0xE2, 0x4C, 0x2C, 0x59, 
			0xA9, 0xDA, 0xB9, 0xB2, 0x75, 0x1B, 0xF6, 0x42, 0xF2, 0xEF, 0xC7, 0xF2, 
			0x18, 0xF9, 0x89, 0xBC, 0xA3, 0xFF, 0x8A, 0x23, 0x2E, 0x70, 0x47 };

		static internal X509CertificateCollection coll;

		static TrustAnchors () 
		{
			coll = new X509CertificateCollection ();
			coll.Add (new X509Certificate (msroot));
			coll.Add (new X509Certificate (verisign));
			coll.Add (new X509Certificate (verisign_ts_root));
			coll.Add (new X509Certificate (thawte));
		}

		public X509CertificateCollection Anchors {
			get { return coll; }
		}
	}
}
