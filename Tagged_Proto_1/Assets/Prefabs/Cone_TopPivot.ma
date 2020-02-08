//Maya ASCII 2018 scene
//Name: Cone_TopPivot.ma
//Last modified: Sat, Apr 07, 2018 01:09:25 PM
//Codeset: UTF-8
requires maya "2018";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2018";
fileInfo "version" "2018";
fileInfo "cutIdentifier" "201706261615-f9658c4cfc";
fileInfo "osv" "Mac OS X 10.13.3";
fileInfo "license" "student";
createNode transform -n "pCone1";
	rename -uid "EE3B3B0A-044A-8DBC-FC2B-14848FE421FA";
	setAttr ".t" -type "double3" 4.8407774719381234 -43.825559692112165 7.8324540642781493 ;
	setAttr ".s" -type "double3" 5 10 5 ;
	setAttr ".rp" -type "double3" -7.4782360970360173e-08 46.427091674534054 1.4028117867326273e-07 ;
	setAttr ".sp" -type "double3" -1.4956472726979086e-08 4.6427091674534298 2.8056233780660023e-08 ;
	setAttr ".spt" -type "double3" -5.9825888243381087e-08 41.784382507080622 1.1222494489260271e-07 ;
createNode mesh -n "pConeShape1" -p "pCone1";
	rename -uid "8693A05E-9B40-0E21-FFD8-4FB61E011FB7";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ai_translator" -type "string" "polymesh";
createNode polyCone -n "polyCone1";
	rename -uid "589D0978-C949-DC96-8E88-5091865788F4";
	setAttr ".r" 3.0640551879322766;
	setAttr ".h" 9.2854183145299647;
	setAttr ".cuv" 3;
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 2 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 4 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :initialShadingGroup;
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultRenderGlobals;
	setAttr ".ren" -type "string" "arnold";
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
connectAttr "polyCone1.out" "pConeShape1.i";
connectAttr "pConeShape1.iog" ":initialShadingGroup.dsm" -na;
// End of Cone_TopPivot.ma
