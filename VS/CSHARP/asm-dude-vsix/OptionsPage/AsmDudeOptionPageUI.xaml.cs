﻿// The MIT License (MIT)
//
// Copyright (c) 2016 H.J. Lebbink
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using AsmDude.Tools;
using AsmTools;
using System.Windows.Controls;

namespace AsmDude.OptionsPage {
    /// <summary>
    /// Interaction logic for AsmDudeOptionPageUI.xaml
    /// </summary>
    public partial class AsmDudeOptionsPageUI : UserControl {

        public AsmDudeOptionsPageUI() {
            InitializeComponent();
            version_UI.Content = "AsmDude v" + typeof(AsmDudePackage).Assembly.GetName().Version.ToString() + " (" + ApplicationInformation.CompileDate.ToString()+")";
        }

        #region Asm Documentation
        public bool useAsmDoc {
            get { return (useAsmDoc_UI.IsChecked.HasValue) ? useAsmDoc_UI.IsChecked.Value : false; }
            set { useAsmDoc_UI.IsChecked = value; }
        }

        public string asmDocUrl {
            get { return asmDocUrl_UI.Text; }
            set { asmDocUrl_UI.Text = value; }
        }
        #endregion Asm Documentation

        #region Code Folding
        public bool useCodeFolding {
            get { return (useCodeFolding_UI.IsChecked.HasValue) ? useCodeFolding_UI.IsChecked.Value : false; }
            set { useCodeFolding_UI.IsChecked = value; }
        }

        public bool isDefaultCollaped {
            get { return (isDefaultCollaped_UI.IsChecked.HasValue) ? isDefaultCollaped_UI.IsChecked.Value : false; }
            set { isDefaultCollaped_UI.IsChecked = value; }
        }

        public string beginTag {
            get { return beginTag_UI.Text; }
            set { beginTag_UI.Text = value; }
        }

        public string endTag {
            get { return endTag_UI.Text; }
            set { endTag_UI.Text = value; }
        }
        #endregion Code Folding

        #region Syntax Highlighting

        public bool useSyntaxHighlighting {
            get { return (useSyntaxHighlighting_UI.IsChecked.HasValue) ? useSyntaxHighlighting_UI.IsChecked.Value : false; }
            set { useSyntaxHighlighting_UI.IsChecked = value; }
        }

        public AssemblerEnum usedAssembler {
            get {
                if (usedAssemblerMasm_UI.IsChecked.HasValue && usedAssemblerMasm_UI.IsChecked.Value) return AssemblerEnum.MASM;
                if (usedAssemblerNasm_UI.IsChecked.HasValue && usedAssemblerNasm_UI.IsChecked.Value) return AssemblerEnum.NASM;
                return AssemblerEnum.MASM;
            }
            set {
                switch (value) {
                    case AssemblerEnum.MASM:
                        usedAssemblerMasm_UI.IsChecked = true;
                        usedAssemblerNasm_UI.IsChecked = false;
                        break;
                    case AssemblerEnum.NASM:
                        usedAssemblerMasm_UI.IsChecked = false;
                        usedAssemblerNasm_UI.IsChecked = true;
                        break;
                }
            }
        }

        public System.Drawing.Color colorMnemonic {
            get {
                if (colorMnemonic_UI.SelectedColor.HasValue) {
                    return AsmDudeToolsStatic.convertColor(colorMnemonic_UI.SelectedColor.Value);
                } else {
                    //AsmDudeToolsStatic.Output("INFO: AsmDudeOptionsPageUI.xaml: colorMnemonic_UI has no value, assuming BLUE");
                    return System.Drawing.Color.Blue;
                }
            }
            set { colorMnemonic_UI.SelectedColor = AsmDudeToolsStatic.convertColor(value); }
        }

        public System.Drawing.Color colorRegister {
            get {
                if (colorRegister_UI.SelectedColor.HasValue) {
                    return AsmDudeToolsStatic.convertColor(colorRegister_UI.SelectedColor.Value);
                } else {
                    return System.Drawing.Color.DarkRed;
                }
            }
            set { colorRegister_UI.SelectedColor = AsmDudeToolsStatic.convertColor(value); }
        }

        public System.Drawing.Color colorRemark {
            get {
                if (colorRemark_UI.SelectedColor.HasValue) {
                    return AsmDudeToolsStatic.convertColor(colorRemark_UI.SelectedColor.Value);
                } else {
                    return System.Drawing.Color.Green;
                }
            }
            set { colorRemark_UI.SelectedColor = AsmDudeToolsStatic.convertColor(value); }
        }

        public System.Drawing.Color colorDirective {
            get {
                if (colorDirective_UI.SelectedColor.HasValue) {
                    return AsmDudeToolsStatic.convertColor(colorDirective_UI.SelectedColor.Value);
                } else {
                    return System.Drawing.Color.Magenta;
                }
            }
            set { colorDirective_UI.SelectedColor = AsmDudeToolsStatic.convertColor(value); }
        }

        public System.Drawing.Color colorConstant {
            get {
                if (colorConstant_UI.SelectedColor.HasValue) {
                    return AsmDudeToolsStatic.convertColor(colorConstant_UI.SelectedColor.Value);
                } else {
                    return System.Drawing.Color.Chocolate;
                }
            }
            set { colorConstant_UI.SelectedColor = AsmDudeToolsStatic.convertColor(value); }
        }

        public System.Drawing.Color colorJump {
            get {
                if (colorJump_UI.SelectedColor.HasValue) {
                    return AsmDudeToolsStatic.convertColor(colorJump_UI.SelectedColor.Value);
                } else {
                    return System.Drawing.Color.Blue;
                }
            }
            set { colorJump_UI.SelectedColor = AsmDudeToolsStatic.convertColor(value); }
        }

        public System.Drawing.Color colorLabel {
            get {
                if (colorLabel_UI.SelectedColor.HasValue) {
                    return AsmDudeToolsStatic.convertColor(colorLabel_UI.SelectedColor.Value);
                } else {
                    return System.Drawing.Color.OrangeRed;
                }
            }
            set { colorLabel_UI.SelectedColor = AsmDudeToolsStatic.convertColor(value); }
        }

        public System.Drawing.Color colorMisc {
            get {
                if (colorMisc_UI.SelectedColor.HasValue) {
                    return AsmDudeToolsStatic.convertColor(colorMisc_UI.SelectedColor.Value);
                } else {
                    return System.Drawing.Color.DarkOrange;
                }
            }
            set { colorMisc_UI.SelectedColor = AsmDudeToolsStatic.convertColor(value); }
        }
        #endregion Syntax Highlighting

        #region Keyword Highlighting
        public bool useKeywordHighlighting {
            get { return (useKeywordHighlighting_UI.IsChecked.HasValue) ? useKeywordHighlighting_UI.IsChecked.Value : false; }
            set { useKeywordHighlighting_UI.IsChecked = value; }
        }
        public System.Drawing.Color _backgroundColor { get; set; }

        public System.Drawing.Color backgroundColor {
            get {
                if (backgroundColor_UI.SelectedColor.HasValue) {
                    return AsmDudeToolsStatic.convertColor(backgroundColor_UI.SelectedColor.Value);
                } else {
                    return System.Drawing.Color.Cyan;
                }
            }
            set { backgroundColor_UI.SelectedColor = AsmDudeToolsStatic.convertColor(value); }
        }
        #endregion

        #region Code Completion
        public bool useCodeCompletion {
            get { return (useCodeCompletion_UI.IsChecked.HasValue) ? useCodeCompletion_UI.IsChecked.Value : false; }
            set { useCodeCompletion_UI.IsChecked = value; }
        }
        public bool useSignatureHelp {
            get { return (useSignatureHelp_UI.IsChecked.HasValue) ? useSignatureHelp_UI.IsChecked.Value : false; }
            set { useSignatureHelp_UI.IsChecked = value; }
        }
        public bool useArch_8086 {
            get { return (useArch_8086_UI.IsChecked.HasValue) ? useArch_8086_UI.IsChecked.Value : false; }
            set { useArch_8086_UI.IsChecked = value; }
        }
        public bool useArch_186 {
            get { return (useArch_186_UI.IsChecked.HasValue) ? useArch_186_UI.IsChecked.Value : false; }
            set { useArch_186_UI.IsChecked = value; }
        }
        public bool useArch_286 {
            get { return (useArch_286_UI.IsChecked.HasValue) ? useArch_286_UI.IsChecked.Value : false; }
            set { useArch_286_UI.IsChecked = value; }
        }
        public bool useArch_386 {
            get { return (useArch_386_UI.IsChecked.HasValue) ? useArch_386_UI.IsChecked.Value : false; }
            set { useArch_386_UI.IsChecked = value; }
        }
        public bool useArch_486 {
            get { return (useArch_486_UI.IsChecked.HasValue) ? useArch_486_UI.IsChecked.Value : false; }
            set { useArch_486_UI.IsChecked = value; }
        }
        public bool useArch_MMX {
            get { return (useArch_MMX_UI.IsChecked.HasValue) ? useArch_MMX_UI.IsChecked.Value : false; }
            set { useArch_MMX_UI.IsChecked = value; }
        }
        public bool useArch_SSE {
            get { return (useArch_SSE_UI.IsChecked.HasValue) ? useArch_SSE_UI.IsChecked.Value : false; }
            set { useArch_SSE_UI.IsChecked = value; }
        }
        public bool useArch_SSE2 {
            get { return (useArch_SSE2_UI.IsChecked.HasValue) ? useArch_SSE2_UI.IsChecked.Value : false; }
            set { useArch_SSE2_UI.IsChecked = value; }
        }
        public bool useArch_SSE3 {
            get { return (useArch_SSE3_UI.IsChecked.HasValue) ? useArch_SSE3_UI.IsChecked.Value : false; }
            set { useArch_SSE3_UI.IsChecked = value; }
        }
        public bool useArch_SSSE3 {
            get { return (useArch_SSSE3_UI.IsChecked.HasValue) ? useArch_SSSE3_UI.IsChecked.Value : false; }
            set { useArch_SSSE3_UI.IsChecked = value; }
        }
        public bool useArch_SSE41 {
            get { return (useArch_SSE41_UI.IsChecked.HasValue) ? useArch_SSE41_UI.IsChecked.Value : false; }
            set { useArch_SSE41_UI.IsChecked = value; }
        }
        public bool useArch_SSE42 {
            get { return (useArch_SSE42_UI.IsChecked.HasValue) ? useArch_SSE42_UI.IsChecked.Value : false; }
            set { useArch_SSE42_UI.IsChecked = value; }
        }
        public bool useArch_SSE4A {
            get { return (useArch_SSE4A_UI.IsChecked.HasValue) ? useArch_SSE4A_UI.IsChecked.Value : false; }
            set { useArch_SSE4A_UI.IsChecked = value; }
        }

        public bool useArch_SSE5 {
            get { return (useArch_SSE5_UI.IsChecked.HasValue) ? useArch_SSE5_UI.IsChecked.Value : false; }
            set { useArch_SSE5_UI.IsChecked = value; }
        }
        public bool useArch_AVX {
            get { return (useArch_AVX_UI.IsChecked.HasValue) ? useArch_AVX_UI.IsChecked.Value : false; }
            set { useArch_AVX_UI.IsChecked = value; }
        }
        public bool useArch_AVX2 {
            get { return (useArch_AVX2_UI.IsChecked.HasValue) ? useArch_AVX2_UI.IsChecked.Value : false; }
            set { useArch_AVX2_UI.IsChecked = value; }
        }
        public bool useArch_AVX512 {
            get { return (useArch_AVX512_UI.IsChecked.HasValue) ? useArch_AVX512_UI.IsChecked.Value : false; }
            set { useArch_AVX512_UI.IsChecked = value; }
        }
        public bool useArch_AVX512VL {
            get { return (useArch_AVX512VL_UI.IsChecked.HasValue) ? useArch_AVX512VL_UI.IsChecked.Value : false; }
            set { useArch_AVX512VL_UI.IsChecked = value; }
        }
        public bool useArch_AVX512DQ {
            get { return (useArch_AVX512DQ_UI.IsChecked.HasValue) ? useArch_AVX512DQ_UI.IsChecked.Value : false; }
            set { useArch_AVX512DQ_UI.IsChecked = value; }
        }
        public bool useArch_AVX512BW {
            get { return (useArch_AVX512BW_UI.IsChecked.HasValue) ? useArch_AVX512BW_UI.IsChecked.Value : false; }
            set { useArch_AVX512BW_UI.IsChecked = value; }
        }

        public bool useArch_AVX512ER {
            get { return (useArch_AVX512ER_UI.IsChecked.HasValue) ? useArch_AVX512ER_UI.IsChecked.Value : false; }
            set { useArch_AVX512ER_UI.IsChecked = value; }
        }
        public bool useArch_AVX512PF {
            get { return (useArch_AVX512PF_UI.IsChecked.HasValue) ? useArch_AVX512PF_UI.IsChecked.Value : false; }
            set { useArch_AVX512PF_UI.IsChecked = value; }
        }
        public bool useArch_AVX512CD {
            get { return (useArch_AVX512CD_UI.IsChecked.HasValue) ? useArch_AVX512CD_UI.IsChecked.Value : false; }
            set { useArch_AVX512CD_UI.IsChecked = value; }
        }
        public bool useArch_AVX512VBMI {
            get { return (useArch_AVX512VBMI_UI.IsChecked.HasValue) ? useArch_AVX512VBMI_UI.IsChecked.Value : false; }
            set { useArch_AVX512VBMI_UI.IsChecked = value; }
        }
        public bool useArch_AVX512IFMA {
            get { return (useArch_AVX512IFMA_UI.IsChecked.HasValue) ? useArch_AVX512IFMA_UI.IsChecked.Value : false; }
            set { useArch_AVX512IFMA_UI.IsChecked = value; }
        }
        public bool useArch_X64 {
            get { return (useArch_X64_UI.IsChecked.HasValue) ? useArch_X64_UI.IsChecked.Value : false; }
            set { useArch_X64_UI.IsChecked = value; }
        }
        public bool useArch_BMI1 {
            get { return (useArch_BMI1_UI.IsChecked.HasValue) ? useArch_BMI1_UI.IsChecked.Value : false; }
            set { useArch_BMI1_UI.IsChecked = value; }
        }
        public bool useArch_BMI2 {
            get { return (useArch_BMI2_UI.IsChecked.HasValue) ? useArch_BMI2_UI.IsChecked.Value : false; }
            set { useArch_BMI2_UI.IsChecked = value; }
        }
        public bool useArch_P6 {
            get { return (useArch_P6_UI.IsChecked.HasValue) ? useArch_P6_UI.IsChecked.Value : false; }
            set { useArch_P6_UI.IsChecked = value; }
        }
        public bool useArch_X86_64 {
            get { return (useArch_X86_64_UI.IsChecked.HasValue) ? useArch_X86_64_UI.IsChecked.Value : false; }
            set { useArch_X86_64_UI.IsChecked = value; }
        }
        public bool useArch_IA64 {
            get { return (useArch_IA64_UI.IsChecked.HasValue) ? useArch_IA64_UI.IsChecked.Value : false; }
            set { useArch_IA64_UI.IsChecked = value; }
        }
        public bool useArch_FPU {
            get { return (useArch_FPU_UI.IsChecked.HasValue) ? useArch_FPU_UI.IsChecked.Value : false; }
            set { useArch_FPU_UI.IsChecked = value; }
        }
        public bool useArch_FMA {
            get { return (useArch_FMA_UI.IsChecked.HasValue) ? useArch_FMA_UI.IsChecked.Value : false; }
            set { useArch_FMA_UI.IsChecked = value; }
        }
        public bool useArch_TBM {
            get { return (useArch_TBM_UI.IsChecked.HasValue) ? useArch_TBM_UI.IsChecked.Value : false; }
            set { useArch_TBM_UI.IsChecked = value; }
        }
        public bool useArch_AMD {
            get { return (useArch_AMD_UI.IsChecked.HasValue) ? useArch_AMD_UI.IsChecked.Value : false; }
            set { useArch_AMD_UI.IsChecked = value; }
        }
        public bool useArch_PRIV {
            get { return (useArch_PRIV_UI.IsChecked.HasValue) ? useArch_PRIV_UI.IsChecked.Value : false; }
            set { useArch_PRIV_UI.IsChecked = value; }
        }
        public bool useArch_PENT {
            get { return (useArch_PENT_UI.IsChecked.HasValue) ? useArch_PENT_UI.IsChecked.Value : false; }
            set { useArch_PENT_UI.IsChecked = value; }
        }
        public bool useArch_NEHALEM {
            get { return (useArch_NEHALEM_UI.IsChecked.HasValue) ? useArch_NEHALEM_UI.IsChecked.Value : false; }
            set { useArch_NEHALEM_UI.IsChecked = value; }
        }
        public bool useArch_WILLAMETTE {
            get { return (useArch_WILLAMETTE_UI.IsChecked.HasValue) ? useArch_WILLAMETTE_UI.IsChecked.Value : false; }
            set { useArch_WILLAMETTE_UI.IsChecked = value; }
        }
        public bool useArch_PRESCOTT {
            get { return (useArch_PRESCOTT_UI.IsChecked.HasValue) ? useArch_PRESCOTT_UI.IsChecked.Value : false; }
            set { useArch_PRESCOTT_UI.IsChecked = value; }
        }
        public bool useArch_WESTMERE {
            get { return (useArch_WESTMERE_UI.IsChecked.HasValue) ? useArch_WESTMERE_UI.IsChecked.Value : false; }
            set { useArch_WESTMERE_UI.IsChecked = value; }
        }

        public bool useArch_SANDYBRIDGE {
            get { return (useArch_SANDYBRIDGE_UI.IsChecked.HasValue) ? useArch_SANDYBRIDGE_UI.IsChecked.Value : false; }
            set { useArch_SANDYBRIDGE_UI.IsChecked = value; }
        }
        public bool useArch_KATMAI {
            get { return (useArch_KATMAI_UI.IsChecked.HasValue) ? useArch_KATMAI_UI.IsChecked.Value : false; }
            set { useArch_KATMAI_UI.IsChecked = value; }
        }
        public bool useArch_FUTURE {
            get { return (useArch_FUTURE_UI.IsChecked.HasValue) ? useArch_FUTURE_UI.IsChecked.Value : false; }
            set { useArch_FUTURE_UI.IsChecked = value; }
        }
        public bool useArch_3DNOW {
            get { return (useArch_3DNOW_UI.IsChecked.HasValue) ? useArch_3DNOW_UI.IsChecked.Value : false; }
            set { useArch_3DNOW_UI.IsChecked = value; }
        }
        public bool useArch_PROT {
            get { return (useArch_PROT_UI.IsChecked.HasValue) ? useArch_PROT_UI.IsChecked.Value : false; }
            set { useArch_PROT_UI.IsChecked = value; }
        }
        public bool useArch_CYRIX {
            get { return (useArch_CYRIX_UI.IsChecked.HasValue) ? useArch_CYRIX_UI.IsChecked.Value : false; }
            set { useArch_CYRIX_UI.IsChecked = value; }
        }
        public bool useArch_CYRIXM {
            get { return (useArch_CYRIXM_UI.IsChecked.HasValue) ? useArch_CYRIXM_UI.IsChecked.Value : false; }
            set { useArch_CYRIXM_UI.IsChecked = value; }
        }
        public bool useArch_VMX {
            get { return (useArch_VMX_UI.IsChecked.HasValue) ? useArch_VMX_UI.IsChecked.Value : false; }
            set { useArch_VMX_UI.IsChecked = value; }
        }
        public bool useArch_RTM {
            get { return (useArch_RTM_UI.IsChecked.HasValue) ? useArch_RTM_UI.IsChecked.Value : false; }
            set { useArch_RTM_UI.IsChecked = value; }
        }
        public bool useArch_MPX {
            get { return (useArch_MPX_UI.IsChecked.HasValue) ? useArch_MPX_UI.IsChecked.Value : false; }
            set { useArch_MPX_UI.IsChecked = value; }
        }
        public bool useArch_MIB {
            get { return (useArch_MIB_UI.IsChecked.HasValue) ? useArch_MIB_UI.IsChecked.Value : false; }
            set { useArch_MIB_UI.IsChecked = value; }
        }
        public bool useArch_SHA {
            get { return (useArch_SHA_UI.IsChecked.HasValue) ? useArch_SHA_UI.IsChecked.Value : false; }
            set { useArch_SHA_UI.IsChecked = value; }
        }
        #endregion

        #region Intellisense
        public bool showUndefinedLabels {
            get { return (showUndefinedLabels_UI.IsChecked.HasValue) ? showUndefinedLabels_UI.IsChecked.Value : false; }
            set { showUndefinedLabels_UI.IsChecked = value; }
        }
        public bool showClashingLabels {
            get { return (showClashingLabels_UI.IsChecked.HasValue) ? showClashingLabels_UI.IsChecked.Value : false; }
            set { showClashingLabels_UI.IsChecked = value; }
        }
        public bool decorateUndefinedLabels {
            get { return (decorateUndefinedLabels_UI.IsChecked.HasValue) ? decorateUndefinedLabels_UI.IsChecked.Value : false; }
            set { decorateUndefinedLabels_UI.IsChecked = value; }
        }
        public bool decorateClashingLabels {
            get { return (decorateClashingLabels_UI.IsChecked.HasValue) ? decorateClashingLabels_UI.IsChecked.Value : false; }
            set { decorateClashingLabels_UI.IsChecked = value; }
        }
        #endregion
    }
}
