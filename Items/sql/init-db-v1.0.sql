CREATE TABLE public."DbEnum"
(
    "ID"            bigint      NOT NULL,--枚举 ID
    "TextCN"        text        NOT NULL,--枚举显示的中文名称
    "TextEN"        text        NOT NULL,--枚举显示的英文名称
    "ParentID"      bigint      NOT NULL,--父节点 ID
    "Description"   text        NOT NULL,--枚举描述
    PRIMARY KEY ("ID")
);

CREATE TABLE public."Book"
(
    "Uid"           uuid        NOT NULL,--书籍 ID
    "Name"          text        NOT NULL,--书名
    "Author"        text        NOT NULL,--作者
    PRIMARY KEY ("Uid")
);

CREATE TABLE public."Volume"--卷
(
    "BookUid"       uuid        NOT NULL references "Book"("Uid"),      --小说GUID
    "No"            bigint      NOT NULL,       --卷编号
    "Name"          text        NOT NULL,       --卷名称
    PRIMARY KEY ("BookUid","No")
);

CREATE TABLE public."Chapter"--章节
(
    "Uid"           uuid        NOT NULL,
    "BookUid"       uuid        NOT NULL references "Book"("Uid"),      --小说GUID
    --"ContextGuid"   uuid        NOT NULL references "Content"("GUID"),  --内容GUID
    "VolumeNo"      bigint      NOT NULL,       --卷编号
    "VolumeIndex"   bigint      NOT NULL,       --卷内序号
    "Text"          text        NOT NULL,
    "Name"          text        NOT NULL,       --小说名称
    "PublishTime"   timestamp   NOT NULL,       --章节发布时间
    "WordCount"     int         NOT NULL,       --字数
    "Vip"           boolean     NOT NULL,
    "NeedCrawl"     boolean     NOT NULL,
    PRIMARY KEY ("Uid")
);

CREATE TABLE public."NovelCrawl"--爬取小说需要的Url
(
    "BookUid"        uuid       NOT NULL references "Book"("Uid"),--小说
    "Url"            text       NOT NULL,--爬取小说使用的Url
    "NCType"         bigint     NOT NULL references "DbEnum"("ID"),--官网目录，第三方目录
    PRIMARY KEY ("BookUid","Url")
);

CREATE TABLE public."Host"--域名
(
    "Uid"           uuid        NOT NULL,
    "Name"          text        NOT NULL UNIQUE,       --域名名称
    PRIMARY KEY ("Uid")
);

CREATE TABLE public."Url"--Url
(
    "HostUid"       uuid        NOT NULL references "Host"("Uid"),--所属的域名
    "RelativPath"   text        NOT NULL,       --相对路径
    "UType"         bigint      NOT NULL references "DbEnum"("ID"),--小说目录、小说章节
    "LastCrawlTime" timestamp   NOT NULL,       --url上次爬取时间
    PRIMARY KEY ("HostUid","RelativPath")
);

CREATE TABLE public."PageParse"--Html 页面解析
(
    "Url"           text        NOT NULL,
    "UType"         bigint      NOT NULL references "DbEnum"("ID"),--小说目录、小说章节
    "MinLength"     bigint      NOT NULL,        --html 页面最小长度
    "SScriptCode"   text        NOT NULL,        --SScriptCode 代码
    PRIMARY KEY ("Url","UType")
);

INSERT INTO "DbEnum" VALUES (0,'枚举','Enum',-1,'');

-- 1 ~ 30
INSERT INTO "DbEnum" VALUES (1,'小说状态','Enum',0,'');
INSERT INTO "DbEnum" VALUES (2,'页面类型','Page Type',0,'');
INSERT INTO "DbEnum" VALUES (3,'小说爬取类型','Url Type',0,'');

INSERT INTO "DbEnum" VALUES (31,'连载','Enum',1,'');
INSERT INTO "DbEnum" VALUES (32,'完结','Enum',1,'');

INSERT INTO "DbEnum" VALUES (41,'未知','Unknown',2,'');
INSERT INTO "DbEnum" VALUES (42,'小说目录','Enum',2,'');
INSERT INTO "DbEnum" VALUES (43,'小说正文','Enum',2,'');

INSERT INTO "DbEnum" VALUES (51,'官网目录','Enum',3,'');
INSERT INTO "DbEnum" VALUES (52,'第三方目录','Enum',3,'');