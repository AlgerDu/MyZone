CREATE TABLE public."DbEnum"
(
    "ID"            bigint      NOT NULL,--ö�� ID
    "TextCn"        text        NOT NULL,--ö����ʾ����������
    "TextEn"        text        NOT NULL,--ö����ʾ��Ӣ������
    "ParentID"      bigint      NOT NULL,--���ڵ� ID
    "Description"   text        NOT NULL,--ö������
    PRIMARY KEY ("ID")
);

CREATE TABLE public."Content"
(
    "Uid"           uuid        NOT NULL,
    "Txt"           text        NOT NULL,
    "CreateTime"    timestamp   NOT NULL,
    "EditeTime"     timestamp,
    "ContentType"   bigint      NOT NULL references "DbEnum"("ID"),--���͡���Ϣ��С˵
    --"Language"      bigint      NOT NULL references "DbEnum"("ID"),--���ġ�Ӣ��
    PRIMARY KEY ("Uid")
);

CREATE TABLE public."Book"
(
    "Uid"           uuid        NOT NULL,   --�鼮 ID
    "Name"          text        NOT NULL,   --����
    "Author"        text,                   --����
    PRIMARY KEY ("Uid")
);

CREATE TABLE public."Volume"--��
(
    "BookUid"       uuid        NOT NULL references "Book"("Uid"),      --С˵GUID
    "No"            bigint      NOT NULL,       --����
    "Name"          text        NOT NULL,       --������
    PRIMARY KEY ("BookUid","No")
);

CREATE TABLE public."Chapter"--�½�
(
    "BookUid"       uuid        NOT NULL    references "Book"("Uid"),   --С˵GUID
    "VolumeNo"      bigint      NOT NULL,       --����
    "VolumeIndex"   bigint      NOT NULL,       --�������
    "ContextUid"    uuid                    references "Content"("Uid"),  --����GUID
    "Name"          text        NOT NULL,       --С˵����
    "PublishTime"   timestamp,                  --�½ڷ���ʱ��
    "WordCount"     int,                        --����
    "Vip"           boolean     NOT NULL,
    "NeedCrawl"     boolean     NOT NULL,
    PRIMARY KEY ("BookUid", "VolumeNo" ,"VolumeIndex")
);

CREATE TABLE public."NovelCrawl"--��ȡС˵��Ҫ��Url
(
    "BookUid"        uuid       NOT NULL    references "Book"("Uid"),--С˵
    "Url"            text       NOT NULL,       --��ȡС˵ʹ�õ�Url
    "CrawlUrlType"   bigint     NOT NULL    references "DbEnum"("ID"),--����Ŀ¼��������Ŀ¼
    "LastCrawlTime"  timestamp,                 --Url ���һ����ȥʱ��
    PRIMARY KEY ("BookUid","Url")
);

CREATE TABLE public."Host"--����
(
    "Uid"           uuid        NOT NULL,
    "Name"          text        NOT NULL UNIQUE,       --��������
    PRIMARY KEY ("Uid")
);

CREATE TABLE public."Url"--Url
(
    "UrlPath"       text        NOT NULL,       --���·��
    "UType"         bigint      NOT NULL references "DbEnum"("ID"),--С˵Ŀ¼��С˵�½�
    PRIMARY KEY ("UrlPath")
);

CREATE TABLE public."PageParse"--Html ҳ�����
(
    "Url"           text        NOT NULL,
    "PageType"      bigint      NOT NULL references "DbEnum"("ID"),--С˵Ŀ¼��С˵�½�
    "MinLength"     bigint      NOT NULL,        --html ҳ����С����
    "SScriptCode"   text        NOT NULL,        --SScriptCode ����
    PRIMARY KEY ("Url","PageType")
);

INSERT INTO "DbEnum" VALUES (0,'ö��','Enum',-1,'');

-- 1 ~ 30
INSERT INTO "DbEnum" VALUES (1,'С˵״̬','Enum',0,'');
INSERT INTO "DbEnum" VALUES (2,'ҳ������','Page Type',0,'');
INSERT INTO "DbEnum" VALUES (3,'С˵��ȡ����','Url Type',0,'');
INSERT INTO "DbEnum" VALUES (4,'��������','Content Type',0,'');

INSERT INTO "DbEnum" VALUES (31,'����','Enum',1,'');
INSERT INTO "DbEnum" VALUES (32,'���','Enum',1,'');

INSERT INTO "DbEnum" VALUES (41,'δ֪','Unknown',2,'');
INSERT INTO "DbEnum" VALUES (42,'С˵Ŀ¼','Enum',2,'');
INSERT INTO "DbEnum" VALUES (43,'С˵����','Enum',2,'');

INSERT INTO "DbEnum" VALUES (51,'����Ŀ¼','Enum',3,'');
INSERT INTO "DbEnum" VALUES (52,'������Ŀ¼','Enum',3,'');

INSERT INTO "DbEnum" VALUES (61,'δ֪','Unknown',4,'');
INSERT INTO "DbEnum" VALUES (62,'����','Blog',4,'');
INSERT INTO "DbEnum" VALUES (63,'С˵����','Enum',4,'');