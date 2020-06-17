#region Gorgeous Gmage
/* Title:Gmage
 * Author:Iyui
 * Homepage:Iyui.Github.com
 * Background:网上的批处理软件太不好用，自己写了一个，
 *            结果功能越来越多，干脆仿一个PhotoShop好了
 * Rate of progress:PhotoShop 0.3%
 * 
 * 20200521:第一版
 * 20200602:完善批处理
 * 20200603:新增首选项设置
 * 20200604:新增拾色器、图片移动
 * 20200605:新增"最近打开过的文件"
 * 20200609:新增"裁剪"和"画笔"
 * 20200610:新增"腐蚀"、"膨胀"、"骨架提取"等功能
 * 20200611:使用命令模式重构代码
 * 20200612:发现了严重的BUG：
 *          当图片的高度或者宽度或者宽高比值在某个区间内时，
 *          高斯模糊会导致程序闪退、卡死、报错或不能正确处理图片，
 *          具体原因未知，现改用了其他算法
 * 20200612:新增了一些滤镜，新增"撤销全部"和"重做全部"
 * 20200616:新增RGB通道调整、肤色识别
 * 未来的更新
 * 
 * 1、完善撤销、重做
 * 2、抠图
 * 3、图层
 * 4、重写部分算法以加快处理速度
 * 5、修改插件插拔部分
 * 
 * 未来的未来的更新
 * 
 * 自动循迹算法（看着很有意思）
 * 
 * 
 *           ~BBX0: :B0BXB?O?H7=OHOO?7COOCOB0O?OCC7?O77HO>7?C>7>C7>>CC>++>>>777v+7C7O7'`'-:=>7777777CCCCCOCCCCCCC77CC7777>7>'.``.^??O
         ~0BX?_  vX0BBHO?HHv~7HO?OCOOOCC0X??C77C?C>CHC7O?7>>>C>>>OC>>>>>>C7>v+>77O+```'--=777777CCCCCCCCCCCCCCC777777>>>7_.```.~HH
        ~XBB7`   >B0BBO?HHBv~vOO?CCOOOCCHX0O7C7O?7>OH77?O>>>77>>7OC>>>7>7C7>vvv>7C=`````-vC7777>>7CCCCCCCCCCCCC7777>>v~=>^`'``. =B
       '0BB7.   .CB0BHOH?HX>^v7?O>CC??CCOBB7777?O>>??>O?7>>>>>>>7?O>>>C>7C7>v~=+7C~``````_+C77777>7OCOOCCCCCC7C777C>~_'_+~`''.. .>
      .7BBC`    .?B0B??H?HXO^v+HC7OCH?CCC?XO777H7+7?C7O7>>>>>7>>C?C>>>C7777>=^^>77^`..```':7OC77777COOOOOCOCCCCCCC7=-_:_=~''`... .
      +XB>.   . `HB00O???0X0v=>C7OOOH?OCCCHB7>OH+>7C777>>>>>7C>>OO7>>+C777>+=:~777_`...```-:OH?OCC777O?OOOOOCCOC>v~_:vv::_'`..... 
     :0XC.   .- '000H????B00Ov777OC??C?C7CCBH>OOv7+77>>>>>>>CO>7?C>>>+OCC7>+=_=>7+-....```'-vH?HHH?OCO???OOOCC7v:_:=>C+_-''`. ..  
    .CXH-    '^ '000H???HB0H0OO7CCO?CCOOC7CO0?HC+7=77>>>>>>77C>C?7>>>+OCC>>+~:=+7=_'``..```'_CH????HHHHH???OOCv==+7CCC7^-^'.....  
    _BB~     _= '000????HX0HH0O7OCOOCOC?O777CHH>>+~7>>>>>>77>>>OC+>>++?O>>>v~^=vO>~'``..``'^:>H?HHHH??HH????OOOOO?H?OOO7>C_ ....  
    >%>      ^+ '00H???O0X0H?H7COCOCCOOHCCC77CC7C=~7+>>>>>7>>>>?++>>v>?>+>+=^~+CC:`......``:7CCCOOOCC?HHHHH?O?HH?H0H???OO?= ....  
   -0H'      =7 '00H???OBBHHXH>COCCCCCOHC77C7777O:~>+>+>>7>>>>7?=>>7v7C=>>vvv>v>v-`....`.``'=CC777CCC?HHHHH?O?HH?H00?HH?OH7.      
   +X~       ^0^_00HO????%0H$B>CCCCC7COHCC777v>7C++COC>>>7>>7>?>~>>>vO==>777=~:>~'`......`'_>77O?77CC?HHHHH?O?0HH0B0HHHHH0H_   ...
  .?H`       'HHC00HHH?O0%BHXXCCCCCC7CO?CC77>~+>=~+7OOOO?C77>CHv~7>++>_vC?7=::^+_``.......`_vC7OHO77CHHHHHH?OH00H0XB00H0H0Bv    . 
  _BC         vHH????O?0BBB0?0HOOOCC7C?HCC>7=~>>:_~+>>7C?7CO7?Hv+C>v+::C0>=~^:^v-`.......```:7CCHHO7OHHHHHH?CH00HBXB0000HBB?`     
  ~B=         'OH?OO?0BXHH00CO?C?OCC7C??C77>^=>~__~+>v+CC>7>CH>_+7+=^=??7v=^^_~=``......```'-~77OHHOO??HHHHOCH000BXB0000000B~   ..
  v0'         _0BH0BXXXB?HHH77OOHOOOCC7>O77+_v+:__~>++>OC7>>OO::>>=~CX7+>v~::-=_``....``...'_-~77?HH?O?HHH?OC00H0XXX0000000BO.   .
  >O          +BH0XXXXXH?H0H7>7H?CCCC?O>O77=_++___=>vv>?77>7H+_^>v=H#>:>>=^^:-=``.....`.`..`-v=>7C?HOOHH?H?CC00H0XXX000000000_   .
  7>         ~00HBXXXXB?HB0?>+OHOCC777OCHO>:-vv__:v+v=C?v+>?7__=+>B#7`~7+~:^':_``..........`'^CC77C?COHHHHOCO00HBXXB000000HH07. . 
  +v        _00HBXXXXX0HXBHO>7HHOCC7C+v=?B?_`+=-_^+v=vH+:>O?^__~C$$>'`v7=^^^-:```......`....'-vOC7CCC?HHH?OCOBHH0BXB0HHHHHHHH0= ..
  =~        7BH0XXXXXXXXX0?O7OH?C7C7C===7?00^v:--^vv~7O_~OHv--_7%0v'`'>C+~~_:_-`....````....`-_CH7CCC?HHH?C7?0?OH0BBHHHHH??HH0?_`'
  :=       _H00BBBBXXXX%XHOCC?HOCC77C~~=>O=C%H~'-^v=~>:-7O=-:=+?7^-:_:7+vvv=7CO??OO^'-'````.`'-~??C7C?HH?OC7?H?C?H0BHH?HH???C+v~'`
  `v.   _+O0000HHH0XXBHBX?CC?H?CCCCC>:^~=H^'=B0^'^v==^'>O^-_:^:+v_~>-_77+O$@@@@@@@@X-`'```````':COC7O?0H?O77HHOC??H0??H??Cv^_:~7+.
   ~` `+000B0H????0X%BHHHOCOHHC>CCCC=_::~Hv-'~^v^:v==^+7^-__-.->=-^-.+O+O*@@*###@@@@0`.````````:CC77OHC::+CCH?OCC??H??C+~_-_=C?HH+
   ``:HX7C0HOO??OO0%BOHH?CCOH?77CCC7^~=~v?=:_=_`_^+~v+=--__-``~>__-'=O?%@@#$%%%%%#*@@O.````````_7C>7?H=```~O?OCC7??O>=:'-^+7OHHHH0
  . _B0~70HOO??OO?%?_>0HOCOHHC>CCCCv~^+X%%7:^~=^'+>~=_-__'``.->^--^=+0*0X$%%%%%%%$%B@@>.```````'+C7C??v^^-`^??C7+>=_'`-vC????HHHHH
   .OX~+BHCO?OO?H0+. C0?CO?0?+7CCC+:_^0@*#@0vv^:=H>~:-_-'````vv----=$@7v$$XXX%XXXB%v?@*v````...`v7>O??=:^~-.=?7=_``-'-vOHHH??HH000
   ^XvvBHOO?OOCC+-  .O0OC?H07>CCO7~_:?@X+B*@#?v~v=v=:-`````.^+--'''?@H:C$BBX%%$?-_X+^X@H'.``...'>+7OH>:::^^'-=_``:v^_vO???HH?H0000
  .OH+0HOCOO>^-.    `OHCOHXH+77HOH=~?@B^+$%%#@$7_-=='`````.:~---''O@H:.C%0B$%%#C`=Xv.>@*0:``...:++7?O~_:::^_``'^+7v:>O???HHHH00000
  :BCH0OCOC^.       `COOHBXC+>O??%+~X*=.+$XXBX@#O^=~``````^='--'`:$X^. OXHB#$$%%O~B+ vX~+v`....vv+C?7^~~~:'``_>OCv-+???HHHH000000B
  +0O0HCC+-         ~OOHB0H>+70OB0==@0- +$XXX0C*$~~^```'_~^'--'''7%=-  OB70*$$$*H=0+ ++..``.. :+=>O?=^^^:'`_-_COv'~O???H00000B000B
 `OH0HOC^.        `v?H00HH?+>0B0B~=B*H` >%B%$H~%0~~^````''''''`'=~:--` CB===_+#*O=0~ >-.```. '+=+C?+:::-.':~-_O>':7O??HH0B00000B00
 -H00O7~         .>0H00??07v?XH%H:+>+0- >BH##$BBC:^^```````````-_.`''' +%_   _@*v~0_`:````...v+^>?O~^~^`.::~-:7:-+O??HHH0XX0000B00
 :BBHC~.        -C0?0H?OHH+7BBB%?:~:_O~ >0+?H*%HC-_^```````````'````'' :B`   7@0_>X'.`````. :>^~O?>::^^'._^:`^='=OO?HHHH0BXB0000B0
 ~X0?~       ._+HC=70H??HO>O0XX%?^^~_~v ~7` =@$O>''_`````````````````' .v.  .O?~:XC ``````.'+~:>H+~^:::- -:''^:^COCOHHH00BXXB000BB
 vB07.   .`-~7O+:.~0XHH0HCC?HXXXH^:~^:^'`:.`X@CCv`''-'````````````````` -v-`''`-00'``````.`+v_vOv:^^:::- '-`_^~7C?CCHHH00BXXB00B0B
 >XH_   .':^^_`  `?XXHHX?CH??XXXH^^~^:^: ~?~~~:0_`'`'-````````````````'. 7%C~^=H0^_'````..v+^+Ov'~^::::' `--_:>OC?OC?0H0H0XXXBB0B0
.OB=             =XXBH00C?HOOBBBH=~^~::^'.7?v=O>``'`````````````````````.`vOCOH?=+='```.`=+^+7~`_~^::::' `---vOOC??C?0H000XXXXXBB0
`H7             _0XXBHHv>HOOO00?H>^^~^:_:- _C?+``````````````````````````_^-_~~^==_````'vv~>+-.'~::::::' .-'^COOCH?COH0HHBXXXXXXXB
'?_            `CXXBHH?:?07OOOHOH?^:~~:--=::_::'`````````````````````````''`````'`....:+vv>=-``-^~~^:^^` `'_>COOCH?OO?0HHBXXXXXXXX
-+.           .>BXX0HH?v?BCCC7OOH0v_=~:-.'_^^^'`````````````````````````````````...'-~>vv=_'''`_~~::::_` .-vCOOCCB?OO?00HBXXBXXXXX
+^           'vCBX?HHHC+CHHC7C7OH00=~^:_`.``...``````````````````......`..`.``'-_^=+++~:_''''`':^:__--_. _>COOO>OX?OOOHH0XXX0BXXXX
O.          :OvC%?>H??+^O?OC+O7O?0X?~~^-`..```````-'``````````````.......`...``'_^^__-'''''''`_::_____-. ~OOOO7vHXOOOOHH0XXBHBXXXX
~  ..      ~B+_0%~70O?v-??>7>CC7H0XXv^^-`..``````':'```````````````..........````..````'''''`'_~^_---__ .+OOO7=>XXO??OHHBXXB70%XXX
.  .`    .=07 ~%+`OHO?v`CO+>77CC?BB%?^^_`.``````'_:'`````````````````......... .`'-____--'```-+B0O+:_=~ -7OC+~>B%0OHOOHBXXXCvX%XXX
    .    :0?' +0`'??CO=.7C>+77COH0BX0v:_`.``````-:_`````````````````````......-~vv+v+++++v^-'=X$%%BCCO^.^C7v~+0%X???C?0XX%B^+XXXXX
        .70v  C> -?O7C~.>C>+>CCO0HBXX>:_'.```````-^-``````````````````````..-=+=~^:::::^=++++?B0B0?COC:.=+=~+v_=H?HOC?BXX%v-?XXXXB
        -?H_ `O^ -?C+C^.>C+v+7C?0OBXX0v_'`.```````--```````````````````````~v~^::::::::::^~v>+v>>>>>>+-'~=vv~_~7?H?CHXX%%+.>XXXXX0
        _HO' `O: 'O7v7_ vC+vv>C0HO0XX%C_'..```````````````````````````````=+^^^^^^~^^~~~~~~=+>+v+>>>>v'_>C>++OHH???7~7X0^ ~0XXXXBv
        'H7. `O^ 'C7v7- ~C>v++CHOC0XB%O_-`.`````````````````````````````.=>~=====~=====vvv+++CO>++>>>v-^>77CCCCCCO7^''~~`_HBXX%%7.
         +H' .C+ `>7=>` :7>v+>??CO?XXX0:-`.````````````````````````````.:7+=~~~~==~=v+>>>777O?O>>>7>>=-~vvvvvvv==~_-_-'-:vB$X%B>` 
         .>~  vO` +7=v. '>7++O?COOO0XXX=-``.```````````````````````````-+=:_-''_:++++v>77CCOO7C>>OC>v:-~=====^:_-'--------^?%?:   
        .. -' ~?: ~7v=.  ~7+7?OCOOO?XX%7-'..```````````````````````````=^''-''-_':++v+++++v=^+7>COv_-''_____-------_------'-=_    
         `  . ^O+.-7>^   '+>OOCCOOOO0X%0^'````````````````````````````-:`--'`'---'^=v=~~~^^^_^7>O?^.````''--'--__--------__-'_-```
         ..   -CC:.v7:  . ^OCCCCOO?OO0%%7'``.`````````````````````````----`.'--'`-'`:~~~^:_'..=C7CC=-``````````'---_---------_:_-^
     .        .+Cv _C_ .. ^C7CCOOO??O?B%0:'`.````````''``'``'''''''-:'`-_'.`'-'''_.  .```---'``^v>77^`^^` `'`....``'--_---_::-`.:+
   .-.       . :C>:.v^   ->77CCOOOO??O?H%O_'..```````-^::_-`-_::::::-```-'``--''--.....'_^~~^:-``'-:-`_'  `'`........`'-_::-.. '=C
   '+.       ...v7+_-:  :777CCCOOO?O??OC?%?_``.````````'````````.```````''`'-''`-`...`_~:____:=^_'..````. .'`.........`_-`. ...^70
   '7'        . -7>v:-.^77>7CCCOOO?O??7C>?$O-`...````````'''''`````````````'''''-`...-~_------::^:-'````` .`.........`'`..... '=O0
    ++.    .     ^7>+~v77>7+>CCC?HO??O>Ov=%%7-`...```````'''''`````````````'''`'_`.`':_---------_^:'``..'```..   ............._>H0
    '?C_         .v777777>v=+CCOBBO??7>?~_XBBH~`...````````````````````````''``__```-_-----------_^'`-``'``...       .........~C0C
     ~0Hv-.      `=777>>v=~=7CC?X0??C>7?-~%B?BX=`...````````````````````..```'_^_``'_-------------:''_--`.'`..     '`  ......`v??-
     .=OOC+~^::~v>7>>+v===~>CCOBX0?C>>O='H%XHO0%7-...```````````````````..`'-:_-`.`__---------------_::_`.-_-'`....~7        '>H= 
    .  :77777777>+vvvvvv==>77O0XHC7>>OO+?%XX0OOX#0v`..``````````````````.._^__'.``':-------------_-___:_-.`___-'``.-?^`'`... -CO' 
        _v>++++v==vvvv+==>77O00O>>>7OH?H0?????OB%X$O:...``````````````..`=v_-'  '''_''-----------_--_^:_-. .'-__'.. +O`..``` -Ov  
         ._=++vvvvvv+v==>>>OHO>>>>C????OOO?O?OCXBH$#%>`..``````````...`:7>_--.  .'--'-----------------:^_`   .`'-'` _=.      'C:  
           .'-=7>+vv=v+>>7>>>+v:^C??OCCOO???C>O%0H$XO?>~- .```````..`^+OC_--_`   .`-----'---------_----^~_.     -^_'` `^'.   .+-  
           ._v77>+vv+>777+v+=_.`v??CCC????OC>C?%H?$O_>COC~`.`````.'~7O?C:-___'     `---''-----------_---:^'     _^~:-'`~v`    ~-  
      .  `:>7>+v+v+>777+v+v:. 'CHO77COOOOCC>7?B%OH$+^O7v7O7^`..`-~~vOOC^--__'.     '-''-------__---_------_`   .-::~^_-'-.    '_  
       '^>7>+++>>>>77>vvv^'  '7?C>>77777C7v+OOO?OH$+^CC+^v7O>^:=7O=_7O=-_-''`    .`--'--''------'``:-----__-.  .-::~~^_-'.     '. 
     .^+>+++>7>>>>77v=+=' ...7Ov~^::^^^^_'^OC-`+?0#+~C7Cv-:=COOOCCv-+v-_-`.''. .``-'''''''---'``...^_---:___..-``___::~:-_`..```'`
    'v>++>>7>>>>>7>v=+=` .. ^>_.        `v?>` 'C?X%+vC7C7:-_:v>CCC+^^-''..'__-```.'_..```-_'...... ^_--_=^_-.._^` .`-_:^_=~''``...
  ._+>>>7>+>>>7>7>v=+v' .. .~'       .':++:```~?B%=:7C77C=-_-_~~~:_-```..'_:--'`..':.``'--'.....   :_--_v~::'.-:-   .`-_:vv-'`....
 .=7>>C7~~+>77>7>v=v+_......`.    .'-`.```'---__^=_=C++777:__^-````.. .`':^-``'...'_'--''`...      -_--_7v=~-.'__-. .`..`:~-----''
 ^C>>C7::>>>7>7>+vvv+- .......  .  _^_''--''````.._7>:~77C=-_~'````.  .'_^'```'```'-''..```'`..    ':-'~C7+~:``___'  `-'`.`'------
:7>>C+'`+>>>777>+vvv+_.............`:^^-'''--''''`_~:_^>77>__^-```.   `-:'`'`-'`''-'...``'''`'``.  `~'->?C>+='.____`  -__-'-___-_^
C77Cv..v>>>77+>>vvvvv~`.............-:__::::_''''''``-_+77C~_~_````. .`_:'`..```'`'` .`''''''''''. .^`~?OC77>_.-____` `___-~>>>>CO
77C+. ~7>>7Cv-+>vvvvvv:```'``'```````'''-_:_''''''.  `_=7>7+_^_````...`--'. .`-'..'`.`'''''-''''''.`:^O?CCC7>~`-^___-` '____+OOOOO
7C>' '>>>>O+` =7+vvvv=-.```....```````````--'''`. `-'`_=>>>>_^_````````'---`'`''. `.`''''------'''.:>O?OCCC77v'':-__--. '__-:+OOOO
C7- .=7>7C=.  '>>v=v=_                  .......  .'__'_+>>>7^:_`'----'``-_:`.. .. `-`''_:^~~^^~^:-`+HOOOCCC77>:`____--'  '_:_:vOOO
C=  `>7>C~   . -v>+v^.           . .......```.  .--_:-~COOC=_---_-__::_'--:' .. . .:__~^^~===v==+vv??OOOOCC777~.-____-'`  ':::_vOO
C:  '77C=.    ...-:^'       .`''``````'-'--''--'^7COO=+H?7='''``````'-_____- .   . `v=~~~===+7++++>CH?OOOOCCC7=.-_____''.  -:^_^CO
C:  :CC+. .  .......    .````''``....'-`-__-``'_v77C?+^=^_-''-'```````'-_-^^.    .-~v==^~~~vv^~+=~vv>OHOOOCCCC^`'______-`  .-::^CO
C^  ^O7'   ......``    .```````.... `-`-____'--_v==>>_'``..```..````'-_--v0O`    :+>>v~~=v++vv=v~:~+v~>?OOOCCC^'`____-_--.  .'^=OO
O+..>C- .  ......`.   ```...........-''_______-~v=>7_``.. .````..``'__'_7BBB:   :++>+~v>7>>=~~+77+~^~_->HOOCCC:-'-____-__'   ._+CO
COv=C_   .`.....``  .``......  .  .:_`_______--=v+C_........```.``'_--=O00H0+  :+=~v+>>v~=+~__~~~v+=:_--COOOOC::`-_______-.   `=C7
_vCCC^_-_:'....``. .``.....      .>v.-_______-:+vOO-'____----`''`'--_>H00H>>0='vv~~+7v___vv>=:^^~^^=^_-`_?OCOC~_`'_____--''    -+>
 '7C+==^-`.....`. .``.....     `^?O'`_______-_vv>X7_:::^~^::_`'-'`'~O?C007v=OBCv=:v>~'__:=~=+~~>OO>_:^_:'+?O?O~-''_____-'.``    :>
 ^CC_     ....`...``..... ..'-~7?O:.'_____-_~vv+0H:---:^___::'':^^~CC>?0>~vvOBOv^^>~:=~_^~=~v>7++C7>::^:_~?OC~-_-'__---'`.``    `=
`+CC_ .......``.``......   .`-__'_`.-_____:v+vvH0^'__^^_----=__OC7>vv?B+-_^v?0v::+vvC+~~vv~=+=v+OC=++_:::^?O:'-__--__--`...`.    '
`>CC=.``....``.```.....         `-``______v+v=>Xv'_^^^:-_--:O^_>+v==OB>-__:+HH=:^>vC>v~~=~^^^=>>+^~v>^_^::+^'____--_---`...`.     
.~OO7'`'...`````.......         -'`'____-^++v+0C'':_'-----_C?^_==~^CBC--:-:+0?^_~+7++>v=+~^'_^+v^:^=7^_^:~:-___-------'`...``     
..^>v-'...`````.......         .-``'____-=+vvHH' '' _-...'7B7^^~_->B>-'_-':+0O:-v=7+::^^=^:-_^>v-`-+C_-~+^---_--''''````...``    .
. .--_=_.`````.......        .-:-``-____-=+=CB=..`~=_....=B?~:_-->B>'`'_''_v0C__=~>=-:^^=v_::~>v~_:vv='vv----__--''`.......`'   ._
..'''-_^-````...... . .      _^:```-___--=v+BC`...+v...._H0=__-->X7'``-'``-=07-_=_+~^'.:=~:^^=+~:^=:>C:=_--------''`..   ..`'.  '~
.`'`````'```........  ..     __'``'____-^v>HH^'''__....-CH~-_-_CB>_`.`'```'~H7'_v-_=~:_:^~~_:v~-_v^~CO=:-------'-''`     ..`'. .^+
... ...````.............     _:```'___-_vOB?:''`''....'>B=-_-^?0=--``'`....:?C'_v-_^_^_:^`~__v` `v=>OO~'------''''`..   ..`''. -+>
... .......... ..       .    ::```-__--~H0+'..........+X>-_-~00=-:_'`-'._:_^??-_v-:7:'^:  :=^v^'^~v>OC:'-_-_----```.  ...`'-:..~>>
. .  .  .......             `^:```__-:v0?_..`'`''....=B7_--v0?=:^~:'''-^:___v?^^>:_>+^^^_-~^::====_+C+---------'`'.. ..`~+v^: -+>>
.          .       . .....'_^:^```_-~v?B^ .'-__'`...~0>---+B7::~~=_''.`:_-_-'~+=7:_v>v====^^:_^~=>vOO^'--'-----``'. . .>H?+^'.^>>>
          ..      ..'^^^~v>v:_^'.'__>+HO'.''-_` ..'v07--->BC^^~==~''`.`'--__-'^+O^--v=-~>~~^::~~~+777----''''_`.``..  :H?O~'``~>>>
                  .`^vv+++~__::'.-_v>+B7..-`-.`_^~>H>:-:7H>^~~==~:''..-`''--_--_+>--=++vC+=v~=+++7>O+'_---'''' .`....`7?OC_.`-v>>>
  . .`'=`      .  ._vvv+=:-___:'`-^Cv7X= .^~.:C>^^^^--:>?v^~==~~~-``  '-'.'--_---v~'vO7>>777+=C?CH+H='-__--'`  .`....=HO?7'.`_>>>7
   .7^`C'     ..  `~+vv=_--__-:_`->C=O0-.-^-v0?:'-''''_^^_^~==^^:``.  .-'`.--_----=:+OOOCH>Ov^~~^^:^:-----'.   ```..'O?O?+```'>7>7
.  v?. :. .  ...  -v+v^-'-____+~`~C>=?C..'_70C~--__-_~:-'--_::_--`'..  `-' .------_v~OBH>+:--'''''''---`..     .`...v??O?~`'.`>777
  -O_   .~=    .  :+v:'``-__-~7v^7C==H~ -70O~_--___:C?v~~^^:_--`.`'`.. .--  `''----~+7v:_'---------'`'_' ...... 0^.:?CC?C- ...vC77
_:'`    =?>.   . .~+_```'-_--=>>>O>~v?-=0Hv_-__--_~C07~=====~^:' `'.. ..`'...`''---^+_''---''--'--''''-`.'+@@@@@H`.+C:_^_`   .=C77
7v      :C=   .. `=:`````---_v++>C+~>?O07:-_-___=C?HC=======~^_'```...  .-`...'---_:-'----'`'`'''''``.'`.``.`@v'.`CO_+=-v^:=..=CCC
>~.      ::   ...-_`````'--':+++>7v~?0>:-_-_~=::7O7+======~^_'.`'.``.... __`  `'----'--''-'``...`.....````...@='`_@B-@B-@HH@..v7v~
v_`      ...''  '_``````'-'`~++vv>~~O=---_=7C~-:=~~===~~^_-'`..`'..`.....`^'.  .'''''-''''..    .. ...````...@v`--@B_@0`@@@@ -~__-
`..      . -^- -:-``````--`'~++~+>^_:--_~OHC~-_~==~~^:_-'```...`'` ```....-_.   ````.`..``.     .. ...``'`...@v_~`-@@@7 @@X@'^_--_
 .         .. :C+'``````-_`'=+=~>v-_-_=CHO=_-:~~^^:__-''```...```'  .`'````_-.. `.      ..    . ......``'`...@7=_`'>%@. @X^@~_----
             _>7=-``````-_'-==~~7~--_>H?+_--:^::__---'''`````````'`.  .````'_`...        .    ......````'..H@@@@@v`-0@`.':>v:::___
           ..^~_--``````-_'-==~^>^-=CO+:-_-_:____----''''```'''''''`    . `'_'...         .....`````''''`..`'^___'.`...-+~::`.`-_:
           .``'---`````'-_-^~:_:7v>7v:--_''-____----'''``_:'''```..   .```.`':'`.    ...``````'''''``'`''--_:_-_-'.``.`v+__:.   .`
           ..`_---'````'--^^_--^CCv_--__'..`'-----'-'`^>v+~-.    .. .``````.`-:``.````````'''-'`......```-::_-_-'`.`'`=7_-:' ...   

 */
#endregion

#region 以下为正文

#region 引用
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using MaterialSkin;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
using static Gmage.RollBack;
using static Gmage.ImageProcess;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using static Gmage.Config;
#endregion
namespace Gmage
{
    public partial class MainForm : MaterialForm
    {
        #region 注册事件
        /// <summary>
        /// BUTTON事件
        /// </summary>
        private void TsmiClick()
        {
            ToolStripMenuItem[] toolStripMenuItems = new ToolStripMenuItem[]
            {
                tsmi_Gray,tsmi_Complementary,tsmi_Frequency,
                Clockwise180,Clockwise90,Clockwise270,RotateNoneFlipX,RotateNoneFlipY,
                Tsmi_GaussBlur,tsmi_MedianFilter,tsmi_GaussNoise,tsmi_Smoothed,
                tsmi_Corrode,tsmi_Expand,tsmi_Boundary,tsmi_TopHat,tsmi_Skeleton,
                tsmi_Soften,tsmi_Atomization,tsmi_Embossment,tsmi_Cartoonify,tsmi_Skin,
                tsmi_OverExposure,tsmi_Fragment,tsmi_AutoColorGradationAdjust,
                tsmi_AutoContrastAdjust,tsmi_HistagramEqualize,
            };
            foreach (var tsmi in toolStripMenuItems)
            {
                tsmi.Click += (click_sender, click_e) =>
                {
                    Config.Model = (FunctionType)Enum.Parse(typeof(FunctionType), tsmi.Tag.ToString());
                    ResultImage = graphCommand.Execute(Config.Model, ResultImage);
                    GC.Collect();
                };
            }
        }

        /// <summary>
        /// 带阈值功能的事件注册
        /// </summary>
        private void TsmiThresholdClick()
        {
            ToolStripMenuItem[] toolStripMenuItems = new ToolStripMenuItem[]
            {
               tsmi_Lighten,tsmi_Contrast,tsmi_Binarization,tsmi_Polar,tsmi_Robert,tsmi_Sharpen,tsmi_Mosaic,
               tsmi_Wave,tsmi_HighPassProcess,tsmi_MedianFilterProcess,tsmi_MeanFilterProcess,tsmi_GaussFilterProcess,
               tsmi_RadialBlurProcess,tsmi_MaxFilterProcess,tsmi_MinFilterProcess,
               tsmi_DiffusionProcess,tsmi_Posterize,tsmi_ExposureAdjust,tsmi_ColorTemperatureProcess,
               tsmi_GammaCorrectProcess,tsmi_NaturalSaturationProcess,
            };
            foreach (var tsmi in toolStripMenuItems)
            {
                tsmi.Click += (click_sender, click_e) =>
                {
                    Model = (FunctionType)Enum.Parse(typeof(FunctionType), tsmi.Tag.ToString());
                    //ResultImage = SwitchFunc(initBitmap);
                    Open_Threshold_Config(0);
                };
            }
        }

        /// <summary>
        /// 工具栏事件
        /// </summary>
        private void ToolsClickEvent()
        {
            MaterialFlatButton[] flatButtons = new MaterialFlatButton[] { mFB_Empty, mFB_ColorPicker, mFB_Move, mFB_Cut, mFB_Draw, mFB_Select };
            foreach (var flatButton in flatButtons)
            {
                flatButton.Click += (sender, e) =>
                {
                    Tool = (Tools)Enum.Parse(typeof(Tools), flatButton.Tag.ToString());
                };
            }
        }
        #endregion

        #region 消息处理
        /// <summary>
        /// 消息处理
        /// </summary>
        /// <param name="e"></param>
        private void MessageManage(MessageEventArgs e)
        {
            switch (e.messageType)
            {
                case MessageType.ImageReading:
                    mPB_Bar.Visible = true;
                    Thread thread = new Thread(new ParameterizedThreadStart(SetImageShow));
                    thread.Start(e.FileNames);
                    break;
                case MessageType.RunTime:
                    break;
                case MessageType.Message:
                    SetImage_Control(e.Message);
                    break;
                case MessageType.Error:
                    break;
                case MessageType.DeadlyError:
                    MessageBox.Show(e.Message, "致命错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case MessageType.Progress:
                    if ((int)e.Progress < 100)
                    {
                        mPB_Bar.Value = (int)e.Progress;
                    }
                    else
                        mPB_Bar.Visible = false;
                    break;
                case MessageType.History:
                    AddHistoryItems(e.Message);
                    break;
            }
        }

        private void SubthreadMessageReceive(MessageEventArgs e)
        {
            try
            {
                if (this.IsHandleCreated && !this.IsDisposed)
                {
                    MessageEventHandler handler = new MessageEventHandler(MessageManage);
                    this.Invoke(handler, new object[] { e });
                }
            }
            catch (Exception)
            {
                //throw new Exception("", ex);
            }
        }
        #endregion

        #region 变量
        private readonly MaterialSkinManager materialSkinManager;
        Tools _lastTool = Tools.Empty;
        bool _spaceUp = false;
        ToolTip toolTip = new ToolTip();
        int _history_Count = 10;
        int _history_Name_index = 1;
        public Tools Tool { set; get; } = Tools.Empty;
        public Bitmap ResultImage
        {
            set => col.Image = value; get => (Bitmap)col.Image;
        }

        public TabPage SelectedTab
        {
            set => mTC_ImageTab.SelectedTab = value;
            get => mTC_ImageTab.SelectedTab;
        }

        public Bitmap CopyImage
        {
            set; get;
        }

        public Bitmap initBitmap { set; get; }

        Hashtable _htTabImageName = new Hashtable();
        //剪切
        bool canDrag = false;
        bool isCuting = false;
        bool isCutingUp = false;
        //画笔
        bool _isPressed = false;
        public point[] pt = new point[6];
        public int no_of_points = 0;

        public enum PenType
        {
            k_pen = 0x1,
            k_hight_pen = 0x2,
            k_pai_pen
        }

        #endregion

        #region 初始化
        public MainForm()
        {
            InitializeComponent();
            initBitmap = new Bitmap(1, 1);
            ResultImage = initBitmap.Clone() as Bitmap;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme =
                new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            menuStrip1.BackColor = ((int)Primary.BlueGrey900).ToColor();

            if (WindowStateMax)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;

            //Mtb_Color
            tabPage1.BackColor = Color.FromArgb(255, 51, 51, 51);
            //groupBox1.BackColor = ((int)Primary.BlueGrey800).ToColor();
            tB_R.BackColor = Color.FromArgb(255, 51, 51, 51);
            tB_G.BackColor = Color.FromArgb(255, 51, 51, 51);
            tB_B.BackColor = Color.FromArgb(255, 51, 51, 51);

            SetColorRGB();
            
            // pTools.BackColor = Color.FromArgb(255, 55, 71, 79);
            messageClass.OnMessageSend += new MessageEventHandler(SubthreadMessageReceive);
            TsmiClick();
            TsmiThresholdClick();
            ToolsClickEvent();
            SetToolTipPromot();

            this.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Space)//空格键按下可移动图片，仿PS
                {
                    if (_spaceUp)
                    {
                        _lastTool = Tool;
                        _spaceUp = false;
                        Tool = Tools.Move;
                    }
                }
                else if (e.KeyCode == Keys.Menu)
                {

                }
            };
            this.KeyUp += (sender, e) =>
            {
                if (e.KeyCode == Keys.Space)
                {
                    Tool = _lastTool;
                    _spaceUp = true;
                }
                else if (e.KeyCode == Keys.Menu)
                {
                    Tool = _lastTool;
                    _spaceUp = true;
                }
            };
            this.MouseWheel += Zoom_MouseWheel;
            LoadHistory();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Program.MyArgs.Length > 0)
            {
                RollBackMessage(Program.MyArgs);
            }
            Classifier_Load();
            Color_R = int.Parse(GmageConfigXML.XmlHandle.LoadPreferences("Color", "R", "51", "MainForm"));
            Color_G = int.Parse(GmageConfigXML.XmlHandle.LoadPreferences("Color", "G", "51", "MainForm"));
            Color_B = int.Parse(GmageConfigXML.XmlHandle.LoadPreferences("Color", "B", "51", "MainForm"));
            Change_pB_Color();
        }

        /// <summary>
        /// 设置按钮的提示文本
        /// </summary>
        private void SetToolTipPromot()
        {
            toolTip.SetToolTip(mFB_Cut, "裁剪");
            toolTip.SetToolTip(mFB_ColorPicker, "拾色器");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetHistory();
            SaveInfo();
        }
        #endregion

        #region 选项卡及以上的控件功能注册
        private void btn_SelectImage_Click(object sender, EventArgs e)
        {
            ReadInitImage();
        }

        private void ReadInitImage()
        {
            OpenFileDialog oi = new OpenFileDialog
            {
                Filter = "图片(*.jpg,*.jpeg,*.bmp,*.png) | *.jpg;*.jpeg;*.bmp;*.png| 所有文件(*.*) | *.*",
                RestoreDirectory = true,
                FilterIndex = 1,
                Multiselect = true,
            };
            if (oi.ShowDialog() == DialogResult.OK)
            {
                RollBackMessage(oi.FileNames);
            }
        }

        private void SetImageShow(object fileNames)
        {
            var files = (string[])fileNames;
            var count = files.Count();
            float c = 0;
            foreach (var filename in files)
            {
                RollBackMessage(++c / count * 100f);
                SetImageShow(filename);
                RollBackMessage(filename, MessageType.History);
            }
            CheckonIndex();
        }

        private void SetImageShow(string filename)
        {
            var Format = new string[] { ".jpg", ".bmp", ".jpeg", ".png" };
            if (Format.Contains(Path.GetExtension(filename).ToLower()))
            {
                try
                {
                    RollBackMessage(filename);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("不正确的格式", "错误的预期", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetImage_Control(string filename)
        {
            try
            {
                var initImage = (Bitmap)Image.FromFile(filename);
                //ResultImage = initImage.Clone() as Bitmap; //严重的BUG 
                initBitmap = initImage.Clone() as Bitmap;
                if (mtS_Selected.BaseTabControl != mTC_ImageTab)
                {
                    mtS_Selected.BaseTabControl = mTC_ImageTab;
                    mTC_ImageTab.Visible = true;
                    panel1.Visible = false;
                }
                SetTab(Path.GetFileNameWithoutExtension(filename));
                if (!HideTab())
                {
                    materialContextMenuStrip1.Enabled = true;
                    tsm_CloseTabPage.Enabled = true;
                }
                else
                {
                    ResetBitmap();
                }
            }
            catch
            {
                MessageBox.Show("图片打开失败", "错误的预期", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        /// <summary>
        /// 打开文件时tabcontrol显示图片名字
        /// </summary>
        private void SetTab(string imageName)
        {
            imageName = reName(imageName);
            AddPagesIndex(imageName);
            TabPage t = new TabPage(imageName)
            {
                Name = "tp_" + imageName
            };
            mTC_ImageTab.TabPages.Add(t);
            PictureBox _PictureBox = new PictureBox()
            {
                Name = "pb_" + imageName,
            };
            var tp = mTC_ImageTab.TabPages[t.Name];
            tp.Controls.Add(_PictureBox);
            tp.BackColor = Color.FromArgb(255, 51, 51, 51);
            _htTabImageName.Add(t.Name, _PictureBox.Name);
            SelectedTab = tp;
            _PictureBox.Dock = DockStyle.None;
            _PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            _PictureBox.Image = initBitmap.Clone() as Image;
            _PictureBox.Width = _PictureBox.Image.Width;
            _PictureBox.Height = _PictureBox.Image.Height;
            var p = GetControlCenterLocation(tp, _PictureBox);
            _PictureBox.Location = p;
            _PictureBox.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            Point mouse_down = new Point();
            Point mouse_up = new Point();
            Point mouse_wh = new Point();

            Point Cut_StartPoint = new Point();
            int[] RectP = DrawRectangle(0, 0, 0, 0);
            _PictureBox.MouseDown += (sender, e) =>
            {
                switch (Tool)
                {
                    default:
                    case Tools.Empty:
                        break;
                    case Tools.Cut:
                        isCuting = true;
                        _PictureBox.Refresh();
                        mouse_down.X = e.X;
                        mouse_down.Y = e.Y;
                        break;
                    case Tools.Move:
                        canDrag = true;
                        mouse_down.X = -e.X;
                        mouse_down.Y = -e.Y;
                        break;
                    case Tools.RGB_Pick:
                        var c = ((Bitmap)_PictureBox.Image).GetPixel(e.X, e.Y);
                        Pick_RGB(c);
                        break;
                    case Tools.Draw:
                        _isPressed = true;
                        no_of_points = 0;
                        pt[no_of_points].setxy(e.X, e.Y);
                        no_of_points = no_of_points + 1;
                        break;
                }
            };
            _PictureBox.MouseMove += (sender, e) =>
            {
                _PictureBox.Cursor = MouseCursor();
                switch (Tool)
                {
                    default:
                    case Tools.Empty:
                        break;
                    case Tools.Cut:
                        if (isCuting && e.Button == MouseButtons.Left)
                        {
                            Graphics g = _PictureBox.CreateGraphics();
                            _PictureBox.Refresh();
                            var pen = new Pen(Color.Black, 1);
                            float[] dashValues = { 2, 3 };
                            // pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                            pen.DashPattern = dashValues;
                            mouse_up.X = e.X;
                            mouse_up.Y = e.Y;
                            RectP = DrawRectangle(mouse_down.X, mouse_down.Y, mouse_up.X, mouse_up.Y);
                            Cut_StartPoint.X = RectP[0];
                            Cut_StartPoint.Y = RectP[1];
                            mouse_wh.X = RectP[2];
                            mouse_wh.Y = RectP[3];
                            g.DrawRectangle(pen, Cut_StartPoint.X, Cut_StartPoint.Y, mouse_wh.X, mouse_wh.Y);
                            g.Dispose();
                            GC.Collect();
                            break;
                        }

                        break;
                    case Tools.Move:
                        if (e.Button == MouseButtons.Left && canDrag)
                        {
                            _PictureBox.Location = new Point(_PictureBox.Left + e.X + mouse_down.X, _PictureBox.Top + e.Y + mouse_down.Y);
                        }
                        break;
                    case Tools.RGB_Pick:
                        if (e.Button == MouseButtons.Left)
                        {
                            if (e.X > 0 && e.Y > 0 && e.X < _PictureBox.Image.Width && e.Y < _PictureBox.Image.Height)
                            {
                                var c = ((Bitmap)_PictureBox.Image).GetPixel(e.X, e.Y);
                                Pick_RGB(c);
                            }
                        }
                        break;
                    case Tools.Draw:
                        if (_isPressed)
                        {
                            Config.Model = FunctionType.PenDraw;
                            int[] iparameter = new int[] { no_of_points, e.X, e.Y };
                            parameter.iParameter = iparameter;
                            parameter.Points = pt;
                            parameter.Color = FrontColor;
                            ResultImage = graphCommand.Execute(Config.Model, ResultImage, parameter).Clone() as Bitmap;
                            no_of_points++;
                        }
                        break;
                }
            };
            _PictureBox.MouseUp += (sender, e) =>
            {
                switch (Tool)
                {
                    default:
                    case Tools.Empty:
                        break;
                    case Tools.Cut:
                        Config.Model = FunctionType.Cut;
                        int[] Location = new int[] { Cut_StartPoint.X, Cut_StartPoint.Y, mouse_wh.X, mouse_wh.Y };
                        parameter.iParameter = Location;
                        CopyImage = graphCommand.Execute(Config.Model, ResultImage, parameter,false).Clone() as Bitmap;
                        isCutingUp = true;
                        break;
                    case Tools.Move:
                        if (e.Button == MouseButtons.Left)
                        {
                            canDrag = false;
                        }
                        break;
                    case Tools.Draw:
                        this._isPressed = false;
                        no_of_points = 0;
                        break;

                }
            };
            _PictureBox.MouseDoubleClick += (sender, e) =>
            {
                switch (Tool)
                {
                    default:
                    case Tools.Empty:
                        break;
                    case Tools.Cut:
                        if (!(isCuting && isCutingUp))
                            return;
                        if (e.X > Cut_StartPoint.X && e.X < Cut_StartPoint.X + mouse_wh.X
                        && e.Y > Cut_StartPoint.Y && e.Y < Cut_StartPoint.Y + mouse_wh.Y)
                        {
                            isCuting = isCutingUp = false;
                            Config.Model = FunctionType.Cut;
                            int[] Location = new int[] { Cut_StartPoint.X, Cut_StartPoint.Y, mouse_wh.X, mouse_wh.Y };
                            parameter.iParameter = Location;
                            CopyImage = graphCommand.Execute(Config.Model, ResultImage, parameter).Clone() as Bitmap;
                            ResultImage = CopyImage;
                            _PictureBox.Width = ResultImage.Width;
                            _PictureBox.Height = ResultImage.Height;
                            _PictureBox.Location = GetControlCenterLocation(tp, _PictureBox);
                            //Cut(Cut_StartPoint.X, Cut_StartPoint.Y, mouse_wh.X, mouse_wh.Y);
                        }
                        break;
                }
            };
        }
        /// <summary>
        /// 获取[里控件]居中于[外控件]时的左上角坐标
        /// </summary>
        /// <param name="outC"></param>
        /// <param name="inC"></param>
        /// <returns></returns>
        private Point GetControlCenterLocation(Control outC, Control inC)
        {
            var x = 0;
            var y = 0;

            var outW = outC.Width;
            var outH = outC.Height;

            var inW = inC.Width;
            var inH = inC.Height;

            x = (outW - inW) / 2;
            y = (outH - inH) / 2;

            //x = x > 0 ? x : 0;
            //y = y > 0 ? y : 0;

            return new Point(x, y);
        }

        HashSet<string> NameHash = new HashSet<string>();
        private string reName(string name)
        {
            string extension = Path.GetExtension(name);//扩展名
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(name);// 没有扩展名的文件名
            if (!NameHash.Add(name))
            {
                return reName(fileNameWithoutExtension, fileNameWithoutExtension, extension, name);
            }
            return name;
        }

        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="fileNameWithoutExtension">无拓展名的文件名</param>
        /// <param name="original">原始无拓展名的文件名</param>
        /// <param name="extension">拓展名</param>
        /// <param name="name">有拓展名的文件名</param>
        /// <param name="serialNum">序号</param>
        /// <returns></returns>
        private string reName(string fileNameWithoutExtension, string original, string extension, string name, int serialNum = 1)
        {
            name = original + $"({serialNum.ToString()})" + extension;
            serialNum++;
            if (!NameHash.Add(name))
                return reName(fileNameWithoutExtension, original, extension, name, serialNum);
            return name;
        }
        Queue<string> history = new Queue<string>();
        private void SetHistory()
        {
            int index = 1;
            history.Clear();
            HashSet<string> hs_history = new HashSet<string>();
            for (int j = 0; j < tsmi_History.DropDownItems.Count; j++)
            {
                SetHistory("history", $"history{index++}", tsmi_History.DropDownItems[j].Tag.ToString());
            }
        }

        private void LoadHistory()
        {
            for (int i = _history_Count - 1; i > 0; i--)
            {
                var h = LoadHistory("history", $"history{i}", null);
                if (!string.IsNullOrEmpty(h))
                {
                    history.Enqueue(h);
                    AddHistoryItems(i, h);
                }
            }
        }

        /// <summary>
        /// 打开图片信息添加到最近打开
        /// </summary>
        private void AddHistoryItems(string filename)
        {
            AddHistoryItems(_history_Count + _history_Name_index, filename);
            _history_Name_index++;//防止控件重名
            history.Enqueue(filename);//最近打开，最多history_Count项
            if (history.Count > _history_Count)
                history.Dequeue();
        }
        private void AddHistoryItems(int i, string h)
        {
            ToolStripMenuItem items = new ToolStripMenuItem()
            {
                Name = $"tsmi_history{i}",
                Text = $"{h}",
                Tag = h,
            };
            items.Click += (sender, e) =>
            {
                tsmi_History.DropDownItems.Remove(items);//点击后当前item提前到第一行
                                                         // tsmi_History.DropDownItems.Insert(0, items);
                string[] file = new string[] { (string)items.Tag };
                RollBackMessage(file);

                //for (int j = 0; j < tsmi_History.DropDownItems.Count; j++)
                //{
                //    tsmi_History.DropDownItems[j].Text = $"{j + 1} {tsmi_History.DropDownItems[j].Tag.ToString()}";
                //}
            };
            tsmi_History.DropDownItems.Insert(0, items);
            HashSet<string> hs_history = new HashSet<string>();
            for (int j = 0; j < tsmi_History.DropDownItems.Count; j++)//清除相同的记录,时间复杂度N2
            {
                if (!hs_history.Add(tsmi_History.DropDownItems[j].Tag.ToString()))
                {
                    tsmi_History.DropDownItems.RemoveAt(j);
                    j = -1;
                    hs_history.Clear();
                }
            }
            for (int j = 0; j < tsmi_History.DropDownItems.Count; j++)
            {
                tsmi_History.DropDownItems[j].Text = $"{j + 1} {tsmi_History.DropDownItems[j].Tag.ToString()}";
            }
        }

        private void tsmi_Copy_Click(object sender, EventArgs e)
        {
            if (Tool == Tools.Cut)
                Clipboard.SetImage(CopyImage);
            else
                Clipboard.SetImage(ResultImage);
        }
        private void SetHistory(string val1, string val2, string val3)
        {
            GmageConfigXML.XmlHandle.SaveControlValue("MainForm", val1, val2, val3);
        }

        private void SaveInfo()
        {
            GmageConfigXML.XmlHandle.SaveControlValue("MainForm", "Color", "R", Color_R.ToString());
            GmageConfigXML.XmlHandle.SaveControlValue("MainForm", "Color", "G", Color_G.ToString());
            GmageConfigXML.XmlHandle.SaveControlValue("MainForm", "Color", "B", Color_B.ToString());
        }

        private string LoadHistory(string val1, string val2, string val3)
        {
            return GmageConfigXML.XmlHandle.LoadPreferences(val1, val2, val3, "MainForm");
        }


        private void btn_Histogram_Click(object sender, EventArgs e)
        {
            Histogramcs hs = new Histogramcs(ResultImage);
            hs.ShowDialog();
        }

        private void btn_Salt_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.SaltNoise;
            Probability py = new Probability(this, MousePosition)
            {
                InitBitmap = ResultImage,
            };
            SetImageCallback(SaltNoise(ResultImage));
            py.ShowDialog();
        }

        public void SetImageCallback(Bitmap bitmap)
        {
            ResultImage = bitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GmageConfigXML.XmlHandle.SetPreferences("Conventional", "HomePage", "1");
            Config.homePage = 1;
            Config.bReStart = true;
            Application.Exit();
        }

        private void btn_FaceRecognition_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Recognition;
            if (Path.GetExtension(Config.ClassifierPath) == ".xml")
                ResultImage = Recognite_Face(ResultImage, Config.ClassifierPath);
            else
                MessageBox.Show("请先选择分类器", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }



        /// <summary>
        /// 
        /// </summary>
        private void Classifier_Load()
        {
            var path = Application.StartupPath + @"\Classifier\";
            config.FloderExist(path);
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] fi = dir.GetFiles();
            if (fi.Length == 0)
                return;
            foreach (var f in fi)
            {
                if (f.Extension != ".xml")
                    continue;
                ToolStripMenuItem items = new ToolStripMenuItem()
                {
                    Name = f.Name,
                    Text = f.Name,
                    Tag = f.FullName,
                    CheckOnClick = true,
                };
                items.Click += tsmi_Classifier_Click;
                tsmi_Classifier.DropDownItems.Add(items);
            }
        }

        private void AddPagesIndex(string ImageName)
        {
            ToolStripMenuItem items = new ToolStripMenuItem()
            {
                Name = "tsmi_" + ImageName,
                Text = ImageName,
                Tag = "tp_" + ImageName,
                CheckOnClick = true,
            };
            items.Click += tsmi_Index_Click;
            tsmi_Index.DropDownItems.Add(items);
        }

        Config config = new Config();
        private void tsmi_Classifier_Click(object sender, EventArgs e)
        {
            Config.ClassifierPath = (string)((ToolStripMenuItem)sender).Name;
            config.IsCheckedControl((ToolStripMenuItem)sender, tsmi_Classifier);
        }

        private void tsmi_Index_Click(object sender, EventArgs e)
        {
            Config.ClassifierPath = ((ToolStripMenuItem)sender).Name;
            config.IsCheckedControl((ToolStripMenuItem)sender, tsmi_Index);
            SelectedTab = mTC_ImageTab.TabPages[((ToolStripMenuItem)sender).Tag.ToString()];
        }

        private void CheckonIndex()
        {
            int i = 0;
            foreach (ToolStripMenuItem item in tsmi_Index.DropDownItems)
            {
                if (i++ < tsmi_Index.DropDownItems.Count - 1)
                    continue;
                item.Checked = true; //设选中状态为true
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "JPEG (*.jpg,*.jpeg) | *.jpg;*.jpeg",//设置文件类型
                FileName = Guid.NewGuid().ToString(),//设置默认文件名
                AddExtension = true//设置自动在文件名中添加扩展名
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ResultImage.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    MessageBox.Show("保存成功");
                }
                catch { };
            }
        }

        private void Open_Threshold_Config(int hold = 128)
        {
            Process.Threshold ptd = new Process.Threshold(this, MousePosition, hold)
            {
                InitBitmap = ResultImage.Clone() as Bitmap,
            };
            ptd.ShowDialog();
        }

        private void tsmi_About_Click(object sender, EventArgs e)
        {
            string interduce =
           @"* Title:Gorgeous Gmage
               * Author:Iyui
                    * Homepage:Iyui.Github.com
                        * 网上的批处理软件太不好用
                            * 自己写了一个
                        * 功能抽时间开发
                    * BUG看心情修复
             *错开是为了不花眼
         * © 2020";
            MessageBox.Show(interduce, "奇怪的功能增加了");

            //Clipboard.SetText("Iyui.Github.com");
        }

        PictureBox col = new PictureBox();
        private void materialTabSelector1_TabIndexChanged(object sender, EventArgs e)
        {
            ResetBitmap();
        }

        private void ResetBitmap()
        {
            if (SelectedTab is null)
                return;
            var TabName = SelectedTab.Name;
            var selectedTabName = (string)_htTabImageName[TabName];

            config.IsCheckedControl(tsmi_Index, TabName);
            col = (PictureBox)SelectedTab.Controls.Find(selectedTabName, true)[0];
            if (!(col.Image is null))
                initBitmap = (Bitmap)col.Image;
        }

        private void tsm_CloseTabPage_Click(object sender, EventArgs e)
        {
            Remove();
            if (HideTab())
            {
                materialContextMenuStrip1.Enabled = false;
            }
        }

        /// <summary>
        /// 删除当前选中的选项卡
        /// </summary>
        public void Remove()
        {
            // 删除时判断是否还存在TabPage
            if (mTC_ImageTab.SelectedIndex > -1)
            {
                if (HideTab())
                    return;
                var SelectedTabName = SelectedTab.Name;
                var TabName = SelectedTabName.Substring(3);
                //使用TabControl控件的TabPages属性的Remove方法移除指定的选项卡
                _htTabImageName.Remove(SelectedTabName);
                tsmi_Index.DropDownItems.RemoveByKey("tsmi_" + TabName);
                NameHash.Remove(TabName);
                mTC_ImageTab.TabPages.Remove(SelectedTab);
            }
        }

        private bool HideTab()
        {
            if (mTC_ImageTab.TabPages.Count < 2)
            {
                return true;
            }
            return false;
        }

        private void mTC_ImageTab_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void mTC_ImageTab_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
                RollBackMessage(file);
            }
        }


        private void tsmi_Preferences_Click(object sender, EventArgs e)
        {
            Preferences preferences = new Preferences();
            preferences.ShowDialog();
        }
        #endregion

        #region 工具栏

        #region 拾色器
        #region 调色板
        private void pB_Color_Click(object sender, EventArgs e)
        {
            ColorDialog dlgColor = new ColorDialog();
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                var c = dlgColor.Color;
                pB_Color.BackColor = c;
                Color_R = c.R;
                Color_G = c.G;
                Color_B = c.B;
            }
        }

        public Color FrontColor
        {
            get => pB_Color.BackColor;
        }

        public int Color_R
        {
            get
            {
                int.TryParse(mT_R.Text, out int r);
                if (r > 255)
                    r = 255;
                if (r < 0)
                    r = 0;
                mT_R.Text = r.ToString();
                return r;
            }
            set
            {
                if (value > 255)
                {
                    mT_R.Text = 255.ToString();
                    return;
                }
                if (value < 0)
                {
                    mT_R.Text = 0.ToString();
                    return;
                }
                mT_R.Text = value.ToString();
            }
        }
        public int Color_G
        {
            get
            {
                int.TryParse(mT_G.Text, out int r);
                if (r > 255)
                    r = 255;
                if (r < 0)
                    r = 0;
                mT_G.Text = r.ToString();
                return r;
            }
            set
            {
                if (value > 255)
                {
                    mT_G.Text = 255.ToString();
                    return;
                }
                if (value < 0)
                {
                    mT_G.Text = 0.ToString();
                    return;
                }
                mT_G.Text = value.ToString();
            }
        }

        public int Color_B
        {
            get
            {
                int.TryParse(mT_B.Text, out int r);
                if (r > 255)
                    r = 255;
                if (r < 0)
                    r = 0;
                mT_B.Text = r.ToString();
                return r;
            }
            set
            {
                if (value > 255)
                {
                    mT_B.Text = 255.ToString();
                    return;
                }
                if (value < 0)
                {
                    mT_B.Text = 0.ToString();
                    return;
                }
                mT_B.Text = value.ToString();
            }
        }

        private void SetColorRGB()
        {
            mT_R.TextChanged += (sender, e) =>
            {
                tB_R.Value = Color_R;
                Change_pB_Color();
            };

            mT_G.TextChanged += (sender, e) =>
            {
                tB_G.Value = Color_G;
                Change_pB_Color();
            };

            mT_B.TextChanged += (sender, e) =>
            {
                tB_B.Value = Color_B;
                Change_pB_Color();
            };


            mT_R.KeyPress += InputLimit;

            mT_G.KeyPress += InputLimit;

            mT_B.KeyPress += InputLimit;

            tB_R.Scroll += (sender, e) =>
            {
                Color_R = tB_R.Value;
            };

            tB_G.Scroll += (sender, e) =>
            {
                Color_G = tB_G.Value;
            };

            tB_B.Scroll += (sender, e) =>
            {
                Color_B = tB_B.Value;
            };

        }
       
        private void InputLimit(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 && (int)e.KeyChar != 8) || ((int)e.KeyChar > 57))
            {
                e.Handled = true;
            }
        }

        private void Change_pB_Color()
        {

            pB_Color.BackColor = Color.FromArgb(Color_R, Color_G, Color_B);
        }

        #endregion

       

   
        #region 鼠标拾色
        Point p = MousePosition;

        private void Pick_RGB(Color c)
        {
            Color_R = c.R;
            Color_G = c.G;
            Color_B = c.B;
        }



        #endregion
        #endregion

        #region 裁剪
        /// <summary>
        /// 画矩形
        /// </summary>
        /// <param name="x">左上角的坐标</param>
        /// <param name="y">右下角的坐标</param>
        private Image DrawRectangle(Image image, int x, int y, int width, int height)
        {
            var g = Graphics.FromImage(image);
            var pen = new Pen(Color.Red, 1);
            float[] dashValues = { 2, 3 };
            // pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            pen.DashPattern = dashValues;
            g.DrawRectangle(pen, x, y, width, height);
            ResultImage = (Bitmap)image;
            return image;
        }

        private int[] DrawRectangle(int startX, int startY, int endX, int endY)
        {
            var diffX = endX - startX;
            var diffY = endY - startY;

            if (diffX > 0 && diffY > 0)
                return new int[] { startX, startY, diffX, diffY };
            else
            {
                if (diffX > 0 && diffY < 0)        //仅向上
                {
                    int tmpStartY = startY + diffY;
                    return new int[] { startX, tmpStartY, diffX, -diffY };
                }
                else if (diffX < 0 && diffY < 0)   //向上，且向左
                {
                    int tmpStartX = startX + diffX;
                    int tmpStartY = startY + diffY;
                    return new int[] { tmpStartX, tmpStartY, -diffX, -diffY };
                }
                else if (diffX < 0 && diffY > 0)    //仅向左
                {
                    int tmpStartX = startX + diffX;
                    return new int[] { tmpStartX, startY, -diffX, diffY };
                }
            }
            return new int[] { startX, startY, diffX, diffY };
        }
        #endregion

        #region 放大缩小

        [DllImport("user32.dll")]
        public static extern int WindowFromPoint(int xPoint, int yPoint);

        void Zoom_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Tool != Tools.Zoom)
                return;
            Control c = this.GetChildAtPoint(new Point(e.X, e.Y));
            Point p = PointToScreen(e.Location);
            if (!(c is null) || WindowFromPoint(p.X, p.Y) == this.Handle.ToInt32())
            {
                //向前
                if (e.Delta < 0)
                {
                    Zoom(true, e.X, e.Y);

                }
                //向后
                else if (e.Delta > 0)
                {
                    Zoom(false, e.X, e.Y);
                }
            }
        }

        /// <summary>
        /// 放大缩小
        /// </summary>
        /// <param name="isReduce">true为缩小，false为放大</param>
        private void Zoom(bool isReduce, int X = 0, int Y = 0)
        {
            //col.Location = new Point(col.Location.X-X - 50, col.Location.Y - Y - 80);
            if (isReduce)
            {
                float w = this.col.Width * 0.9f;
                float h = this.col.Height * 0.9f;
                this.col.Size = Size.Ceiling(new SizeF(w, h));
            }
            else
            {
                float w = this.col.Width * 1.1f;
                float h = this.col.Height * 1.1f;
                this.col.Size = Size.Ceiling(new SizeF(w, h));
                col.Invalidate();
            }
            SetLocationCenter();
        }
        #endregion

        #region 鼠标光标样式
        /// <summary>
        /// 鼠标光标样式
        /// </summary>
        /// <returns></returns>
        private System.Windows.Forms.Cursor MouseCursor()
        {
            switch (Tool)
            {
                default:
                case Tools.Empty:
                    return Cursors.Default;
                case Tools.Move:
                    return Cursors.SizeAll;
                case Tools.Cut:
                case Tools.RGB_Pick:
                case Tools.Select:
                    return Cursors.Cross;
            }
        }
        #endregion

        #endregion

        #region 杂项
        /// <summary>
        /// 禁止menustrip响应部分按键
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.RButton | Keys.ShiftKey))
            {
                if (_spaceUp)
                {
                    _lastTool = Tool;
                    _spaceUp = false;
                    Tool = Tools.Zoom;
                }
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        #endregion

        /// <summary>
        /// 撤销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_Undo_Click(object sender, EventArgs e)
        {
            var bitmap = ResultImage;
            if (graphCommand.Undo(ref bitmap))
            {
                ResultImage = bitmap;
                col.Width = ResultImage.Width;
                col.Height = ResultImage.Height;
                SetLocationCenter();
            }
            GC.Collect();
        }

        /// <summary>
        /// 重做
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_Redo_Click(object sender, EventArgs e)
        {
            var bitmap = ResultImage;
            if (graphCommand.Redo(ref bitmap))
            {
                ResultImage = bitmap;
                col.Width = ResultImage.Width;
                col.Height = ResultImage.Height;
                SetLocationCenter();
            }
            GC.Collect();
        }

        private void tsmi_UndoAll_Click(object sender, EventArgs e)
        {
            var bitmap = ResultImage;
            while (graphCommand.Undo(ref bitmap))
            {
                ResultImage = bitmap;
                col.Width = ResultImage.Width;
                col.Height = ResultImage.Height;
                SetLocationCenter();
            }
            GC.Collect();
        }

        private void tsmi_RedoAll_Click(object sender, EventArgs e)
        {
            var bitmap = ResultImage;
            while (graphCommand.Redo(ref bitmap))
            {
                ResultImage = bitmap;
                col.Width = ResultImage.Width;
                col.Height = ResultImage.Height;
                SetLocationCenter();
            }
            GC.Collect();
        }

        private void SetLocationCenter()
        {
            var p = GetControlCenterLocation(SelectedTab, col);
            col.Location = p;
        }

        private void tsmi_Channel_Click(object sender, EventArgs e)
        {
            Process.RGB_Channnels channnels = new Process.RGB_Channnels(this, MousePosition)
            {
                InitBitmap = ResultImage.Clone() as Bitmap,
            };
            channnels.ShowDialog();
        }

        private void tsmi_CharImage_Click(object sender, EventArgs e)
        {
            var dia = MessageBox.Show("该滤镜暂未集成至该软件，会在未来的版本中加入，该滤镜软件源码地址\r\n'https://github.com/Iyui/CharImage',\r\n点击确定访问该网址，点击否复制到剪切板", "https://github.com/Iyui", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (DialogResult.No== dia)
            {
                Clipboard.Clear();
                Clipboard.SetText("https://github.com/Iyui/CharImage");
            }else if(DialogResult.Yes== dia)
            {
                System.Diagnostics.Process.Start("https://github.com/Iyui/CharImage");
            }
        }

        private void tsmi_supTools_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能开发中，会在未来的版本中加入...", "https://github.com/Iyui");
        }
    }
}
#endregion