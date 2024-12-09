﻿using AdventCode2024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2024;

public class Day09DiskFragmenterUnitTests
{
    private string InData = "6732538334646350541916772743509258615276517884833666703086851776494522296474219227632839317595407057736884604731509493952872407769428569242435671380998668865386354672543353633272312289173721666287357020591195147113299289354318318755483944958573494818398342477985505588721814755899215611557536132820511896464176244831371645978887826753698217842240153077675964183296813488698980373121212696644674382028521172242041394043602195132255962311827175784445773312803214733814594879915826718751489337433491803879894053481820517685232761981857858985324542403632825012691978374612172863282340589591687940508395929259568167172348266115704441792372579276911653283177966868891540825421508625976167866648799057589676262354742733427072154195444780828266193129288656547579481799841742224317954819975749628662417944348040488195272348676980399524102964541222115223335194422472967312446838338211536260902323605118877635585833502421453945762984446357475446733522155535117393707118689848197546304435813948468013684619765076539375694963706448139229436580981678436148644179873719363827671275379651582020367964608070493257193090343514949349571434877690707856957036396975813638844251127773557544214041386185492025138357921394312198266119307489213325676942127612756946769292925142875124186489231250183456568174463926869146353886778225892721303360961531596383286212701286697527315020906197311991181713817416247346425747157781146983576139603428613886395769385710887968949220735011317021103945255969821130927634544241563268558078982892469352139896248824259088792942447837762715256496536290694057631088142956952284618471589482351954429844319589287144831159852068454667312266592362582252382465185539744553298765239721582430436864365681164442688716129637782059421850706462772033227039775989812810568597417923122949575387354856863125661884288153331264808138697745518512892325794452198940241646748445204621733443243158107329241657947289368811556444142796655392955984632679279578689751917228411137493240596181588917353245139721845411619493341480394347802811147318412110582640231610432538982872418925902641417248728138586566282887656868674085822329188252488214922733589457137087681725458635133958641633695724557096697872128117991023951289292568383649491381726867882978406020358650545029305573187929345058662730924343991895478844134298902838936210953542434913617778311372756125549122343859385051735531778716874271968753846899392691341261636813749354357587491977928470484687728572302637964468907858708771897547835412871921141577662488685047317566314490444714693323163871138315551353865071376180323482121825951152125421989972932625636056844996991916662369652476926417564317168629792470591583873348142380328338485086258161255344144255352471139075505485485882902673263973173995812284376073588354771298569098198825511377265846675014644196682644546724744958709413472558566080596746843750391672923331844248174662464146551412472949804731555680309895719781906927824691663511738935743159332980495948931879346561429766136990375890997037249079462195747536377476104697354397884843902820559999217462492791882347716345499229278818726780649616983116245549488035338065126785864383273399439825244292143494291489133630286432655072952613848971699169682746695930873388603712578352643842387535295910357199875446897693296626806227717135819957438365736667355675471931248386669251288865271477974659328490186650979260541460719831971229684828849240541684743239249161713389539943154625738475423962673881957673948291637945821812525794806213926767787374788165458381405261513625318354862623691872223358707230498214569336536888473933653384733776818961479339341942317633718516963680441443315068714656148660101980377127671552569483436939542436813817242991727642104631448789222939876568907530154465686965492186579462212091534714776828506911557180194028757463492579985060831218264182541082662969463499456493993912266160442876423247946522264581945595975029926723503721774899123882122231357310484676537521165087965829451394237210857651249811312335332733276444313633856266452612716469515065187632209451177146418299497492849021678055813563692764279147679367394237175515372468801532558416844015489016958735325770194655523720491755871628413344176928797364943254807686886068772594575939815396299375255491379899652938264381289553718470649681925760523636317794438148598423823885794073407795775451211360135680638673881455636997794871182258207286233992516165254694787758887058673771933444657632531151921159945522638696873969331525251462252539692032482140989184889030258830981955938852315128361869747723448712369570703638263622639326701499693148502061993768144284945330989243186281721426883828147857611188232771657185854169773364465518132886597633516890967044685791498677984210605442197438268056353942723968141133226067275637257183169361698069621452847076229115959979639764251042367746262588861226435097796770897961716621338861994738469251769297652292905622983159464599405269254967789535632019687899832454182874991768599650399477266868153014556146921224814218242821538317782318172668929352656539138889378991241871577854197390459553515784972727789796312215529231143060243066231644698069796686404739931768761323145069593031182329912489155199877017772449501988796727426326852690465063856555558290483413905628557276291592144169835285219442292358736784463858787585293733262637956547678087897223271183277169967783517728796623714416368143153335633627587457464874405678899560767754315339979364586429341267797176595019698266463410408935283589797487152430398062936443461130823284664554466264774653805426364158452814445381903244477822418726249386174299799946282467708747745974939223469168818260646110511579354968412229219679755622298031784986763040131585473253496130103617547193277310309329909920545458891869201045756434715423477730104636598561722492383410374067417618811165169984497922346757573186569068481233311774873217194371368971246944575837636778243324529640831298937261474764194431784349976163148875421782697622264656502594494773519834337185627029718533324646561661413087536664606339798765372232212928778199994388164422532212169856516126604966497522707594648411137556312465729762762857705484396295265829295179957515237022744348482195433299592971838225993388824044156887479326704651815443212560282425753631705043457097567013118412523078715220744969506390109559371380134921267883573657392946291417646742129329498549957435551445316366971470737880527951306798794384774765564378116552234236437634619726395758861256565920297473264989138314992769415546286015267115112579118194142066237870444892374116902158132546179210463167532856506214991817904834542575659227149559711327156463337367113898954742609728177355125544951382553860225945228066299692239740227638428623728536159730264272363329572720441943323937856520585948385950775398897826556864772535444399103387823481836616904481223515101427277435449657775092895895389723403383102417952521351125609491425986216778615368939896488213513478261638971184208355447914705045232583746087606674148191531024113715211017817325475479918870271279368042421780824778366824572233874493616731272299111813133643368081682682288982233361824335144174601528135257122490972199974592711664314029441460238330193626667532731880968337418565116478503977931053411162729271432960394588242447253349531585963254762130109757965921547165493222299043821826881332246921152886687355763334645613348121169277758677588068196635691256618937157329627235879087574770656841124235436756129836542770477637617047607425956343175986613517158912325563428656333334262724798238946785286418745121769141543739983636165947663240737311646847652937992249357485743035204423225377992672303046412876537265429771758649504310429354908243219279626637279586928242448188586928999466697050893950603160248577412517861622588376111419767885548839115317672482209912521182655293113829701112262651848733603272427964595035479416578586959589705328973945635772951781837653203098448973461346109324487713354724845934331833578851989482217147551856298041867637647357427561432283166037619285584521701885371083857640704673213062924447442411819433126642723917127912189631544960638417659455638257305273487729726354105289292262218142452360507559814078703272983724839075553110713460987195499654904460135140995082963492484670584266347365172428574479775266265124708542944020507812837297567530945033889792509256711464177039789787169467338723635633444927907238797712127363706426357567116752312128405966165361228528315548821578964387202381859243249342606871334762879725575620142720624750854963742798407774494988229688599877564582559739982295416710862939376955457528263291989954974050218238605585997342284511568976278255109721907338633221729663339580494581238791427268211234488784843920482823369839685384636633184744251199684150467190258757559679562755207826326992269775979025978938942240347864962797398184507032791669215820258766362433956246547658213138977812927729621721158499384915174332306468685369176252468365401734637364186033633063921365399447899818716911626693695311217767885615209851546626926639343743765710631331205974154990686590776960916684827037868375339470707216817094703628635178356745336521625179367396345897799015718744353916946365655164889346408862695940795876171594178415936417998461253631328325247956681911421753692619391012285357639974127027484968104539996111302834866733194352285767967310157761764187192791368014501665472964244695544752845776797186884639512092366695807537486692845671193267659437305769331797594756966782686754375275616594694543378567725018631459697153789776273373135744471054897795137314568120102429888411136318425396781421756754809762585655536122862772498594451562819145189436661267483496559959739064415025671075581749164318281065811127395518815060445981751298528321197239321151387214977094691151904947205933821913633326226231404064184372211669276958295998591195992855249619182977302278272268485347955469735748493371895688875095626054169625622933392392452846407788267061329132528355692965107243356897635182837994711591489696241671224560397949848921652754272669686668157963631783467360904172267533471616544039575137165257802399896831245950738158587626516038907118568370383933276623982954694960101388631120477191741756565061577841396492196328981928603980417020804356992393982365507766176114831265192312519925366811342581463458332063478369848266955466639078856116287220347685566855425572457473105742209827113431275532153228379222265224384030313138177970384562282334557068147998889328893079899589506281238825186968499032824812219155549819916981827085637974152865226543869895351917518476203698864226162248975567364831364130714973398314878882736372148511686231614736756393645858487039727697926592984395321498931052355197553121771777958211337169544792886524991356813244132254109167479556755997797076943551555143924193305461775054929529255910764193637686994361136149417294114477376229987935634573101099533477759069701411417522713232502222183334991336171077533965675077686123287731145564886914563151383021133916105769356286524168712954659891933856367520979149703648368724144255344274119555182783955033508277998161472195842193167139415339231962228933591293134926465610603031119842779417249873319478172052202568872386193868252347274122193663547830139751237249686057644664302045318091563554187445232947955434964737349056942126431465274269154717844458358685517667445747486240261785339586427645159320139177967160716279441517828037214150417843243428825723274315753094406381982896785030446754787944111525396015417688219078818379886613377794365826115740264439302868857569586229517572128432217789146495262918146787198043823735587626455750887989335335983736309690365562779755895599892791495650857226482769298235305179777485903590397785684352701090299778915114946696401133539687436836259621266113839358575325557568163094417676727738656357281618932124779451424191403278996398835276165778113667501541427970209869221166911121563574887096688988705067647182928075675015701888996880668817399859126550946476834711794030802280953136925762951845327723869652184480221598181378456161796062414495447958721470808683608341979040454849626453922822998381136272797913171994773661614721905999837136542558315792368511714384658579635413939056143726389330722411647767113556108887849564622323309951703385981463481182686639454096989179154325355095355758685132922359636275848431696391458931647355765636884258364011875139393139402079772845939266281410839267263670284172881644435555225592351497341166803176253526759898949231873792996644382054775556383910436398186624345417114484382342963425888046121065479357491826292164998269384021977242292170493133446261292035843481378686834542644053955871133998318351944673986658552650773858249831524984604867658054751523856026435283265856376881921972858941901879271078198382728117963712436430117362454056499457384196192318867082677691887260583415479224286617822492152470115787126361102083115129314088488592185055704870563674726031795179858028619442598794505037472052207948255743704569191447156161297975591246793530208594873531687036744981947411749110909642862414202192814363936819267343166327564631237295785251611258571397499572393949715962823972415952873530336727236217485049212845504098225154601835603490146440655211604961449260632432356774831773166382546415796385179618184980589739509864708882626090836677994047933217701917641153194463735268941836389271363770894517944796731259649159816183686427445789353421478495936143953242254738426330811119901825141397276835464019225828438590639460589563639634472959105214997082438970349621578364165029375650469381882910709263629065611111111615684786396515882255332212493984128766616026323950516844334029666044773519103171583632818697691279457272162995394268777592964967865223627769471323465126238711208919763859113993698596282996677384923783641461203777646146886835835774172296779181651290895680342768334632165424887057595721976286366022483588627027829024639042104560773399716165719821279358565438881814969215547861752968304067509865694397342368799493294890622565172894518794373014779458106843837773924589301160376794958840544259164785309952745213854274864614782585491236768176242212968021746924994493711757361847907039467846466826401049794824385930687131449932962966271335913537104761152413481351165571371366117491754139596610644280496046677377569217587483634462276455327580364771296396403048383332101313311860322739413880124951889536146160493749624344862823227140377362904953647338422984509827943076308449415663914385992165447623918145561448466120451824367757662599637063873862693444975345401351342285278922888119863245935625853797477215366949881737209364835487256665648487694952867664732246593787822031158328145727455637171132202968638966887086624385893552771258202741124394575072296079161826539046304322603016353216404336437523237333726310198873341930703958103395541712741438226974942630255573325354371538256097963092607713259949446939258020718877909287172793208378467089802657819639901728364345181198351847102780317797235057228977554859893596938520143878174929847069723227292215318496517699507765347474359340791026677784914341445117585727846729749324489657504195849253625497833433611630302024428997941671886958774515959653739898498983833967555490883885394147916038457618928119325599978778178589373879238223818521599713187673531435379131634537221121426946931789583865611258823084898493615447241718335145553434241138864868974967557546246753758067301134914649269065438631589763734562664793278246503583468085593310673642917620311469421579425737562778855013505570469969451762825539505395714351683474138819231635982275788436646076398752628294112232714092307386817243957968711581314382518145465685363388853560672194775271887810211680234865979699813047983741435190834547628311902241111361264270136998266857222513459414964383146553113885381890746482372653656535139677371226491949265344997036977599789818609175134118809859524886264068149466368894417337605234871413949395982722933934199667807660778718499548271082661635448220227516438942447320595413397326766292338032843587229238911270987679704960393972601455309518105396394495969639314318585919795741339025699885681572374996342426619212928851858752701088261099843686104993204260168798219745159670283279864816136494107458571996126888394756261660875131196994475188241764142136877260174052989991357913336993283956777765721620727293154356629299216554366965583574717839135744203452151662867895851428962664671592666249418738432269168174841518191389839929749379423766986864255726467663668725861553904938794479423589679889453327395077698810891217452263522883925658358780779861297764593181528069703795915134262137818266516054911722557643154347505399688334715352911535945176781331588377611397655824165749785210203045337069808170102197945924821934249312352541268922845941467591844098615214789684792745254948287858387332387765471774249157551154246680635499229360858224814046839287872388477147205522912797623286166159865536613378579240192448739527385640937353966213488472543776818577467889486718988041596371147498277569957825355599249974247114629150158612347258434777372021629315815916338368466185351980543450374948256867431680872159168857176370741488531534377157992758472162215175694339803696716598544499921062273077356763794740456889361586979721511791796842686228304517618651638757742390901541199151392962379559413812735424281362239970859519781125851497377999649162129169689816438026438194511762307333537369107482429042898588356174829553214174947955691150502086486854455368441940598079617138501555682657533480461629458778674837275366593347633320897866578371515850205320771870144890317261823124117289758136458161552965616497518064131991471271497133199553997973433297699329345465152555148427267183561667242652716622986013758576521398795941708870536756667872933151754062846086434683476312237833371219716692357255656713986752291197394513766836186941413329228927609254405110265657362697626412693092732634671568529537375344498511282438718038486193392248415979507551976782524490815685821044472844106157533957253843784032195247748068586857501358191870144175382847902885549043232740355233247280372431997356294213749356459390688268467086298920951129724181413835118453138628234173219282946070705246315561383934507987532842753146314149282046944240566759558144132472888743877084307679502498574576435419375876212511475326906283358525784510939788822398772270626254794518783314726727498238543192297128239518964110729233946633674090589958728077992854876674637472906338981047709580132972829589509453681764206772763094666285239142347155503941566825204668912168778023512822165927198575538679951858184838475782419559951820964135654459718674816196904239352444568344326147313679847665627731162397701588574815537572511996921880425825291472997014508799623178943471767161228637965844233283104147969136575750941767644298339941394093885454317728756324961797788681715740968431165624791288698451356590261491755312936166856241884558655766841353161754952266365744804083548827403964882385985031526736537941831386771697277672557458984069897494516787972585259536147184242352868565549558579183857850322852358026254360665144332511905179831828873337696875748936605659442682917526666294416087898917373527822042138887286139395894592331448860978076996055331759305644343325964627941761113138504317522348616571575275508996941481369524637032141152387623534077148124398269813914315347558429508570889290726665594333729885368948692165489693737897918261137114818922854225491649465633828828829379111976293610815951755367171396104692972987371923938794226957808979496468843561955997617450946975389151676193366531907235966344787074915232949259386595497559363874522844707210463835341164606052268397494550832922856163733239969529223941578653598394926663414126576751727882877087442990277338686121674651126190205284657084538780573846299842773543476787614045133889529181319558993397996597156574942043119976138623455464437579278937928916522742584659631461636634299494416718729781461529166370558616403483306218166172323881459011557627704619525486241456289679917560812689155339151967406587282235612093852866181313929413978439741738357354661072918815195850771736962659106293379591919079819180461";
    private string TestData1 = "12345";
    private string TestData2 = "2333133121414131402";


    [Fact]
    public void DiskFragmenter_TestData1_OK()
    {
        var df = new DiskFragmenter(TestData1);
        Assert.NotNull(df);
        Assert.Equal(15, df.TotalBlocks);
        Assert.Equal(5, df.BlockGroups.Count());

        df.FillTheDisk();
        Assert.Equal(2, df.TheDisk[df.TheDisk.Count() - 1]);
        df.FragmentTheDisk();
        Assert.Equal(0, df.TheDisk[df.TheDisk.Count() - 1]);
    }

    [Fact]
    public void DiskFragmenter_TestData2_OK()
    {
        var df = new DiskFragmenter(TestData2);
        Assert.NotNull(df);
        Assert.Equal(42, df.TotalBlocks);
        Assert.Equal(19, df.BlockGroups.Count());

        df.FillTheDisk();
        Assert.Equal(9, df.TheDisk[df.TheDisk.Count() - 1]);
        df.FragmentTheDisk();
        Assert.Equal(0, df.TheDisk[df.TheDisk.Count() - 1]);

        long actual = df.ChecksumTheDisk();
        Assert.Equal(1928, actual);
    }

    [Fact]
    public void Day09_Part1_DiskFragmenter_OK()
    {
        var df = new DiskFragmenter(InData);
        Assert.NotNull(df);
        Assert.Equal(95288, df.TotalBlocks);
        Assert.Equal(19999, df.BlockGroups.Count());

        df.FillTheDisk();
        Assert.Equal(9999, df.TheDisk[df.TheDisk.Count() - 1]);
        df.FragmentTheDisk();
        Assert.Equal(0, df.TheDisk[df.TheDisk.Count() - 1]);

        long actual = df.ChecksumTheDisk();
        Assert.Equal(6367087064415, actual);
    }
}

