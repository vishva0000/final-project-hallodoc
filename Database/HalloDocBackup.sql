PGDMP      
                |            hallodoc    16.1    16.1 L   �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16422    hallodoc    DATABASE     {   CREATE DATABASE hallodoc WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_India.1252';
    DROP DATABASE hallodoc;
                postgres    false                       1259    17539    Admin    TABLE     �  CREATE TABLE public."Admin" (
    "AdminId" integer NOT NULL,
    "AspNetUserId" character varying(128) NOT NULL,
    "FirstName" character varying(100) NOT NULL,
    "LastName" character varying(100),
    "Email" character varying(50) NOT NULL,
    "Mobile" character varying(20),
    "Address1" character varying(500),
    "Address2" character varying(500),
    "City" character varying(100),
    "RegionId" integer,
    "Zip" character varying(10),
    "AltPhone" character varying(20),
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "Status" smallint,
    "IsDeleted" boolean,
    "RoleId" integer
);
    DROP TABLE public."Admin";
       public         heap    postgres    false                       1259    17425    AdminRegion    TABLE     �   CREATE TABLE public."AdminRegion" (
    "AdminRegionId" integer NOT NULL,
    "AdminId" integer NOT NULL,
    "RegionId" integer NOT NULL
);
 !   DROP TABLE public."AdminRegion";
       public         heap    postgres    false                       1259    17424    AdminRegion_AdminRegionId_seq    SEQUENCE     �   CREATE SEQUENCE public."AdminRegion_AdminRegionId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 6   DROP SEQUENCE public."AdminRegion_AdminRegionId_seq";
       public          postgres    false    261            �           0    0    AdminRegion_AdminRegionId_seq    SEQUENCE OWNED BY     e   ALTER SEQUENCE public."AdminRegion_AdminRegionId_seq" OWNED BY public."AdminRegion"."AdminRegionId";
          public          postgres    false    260                       1259    17538    Admin_AdminId_seq    SEQUENCE     �   CREATE SEQUENCE public."Admin_AdminId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public."Admin_AdminId_seq";
       public          postgres    false    277            �           0    0    Admin_AdminId_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public."Admin_AdminId_seq" OWNED BY public."Admin"."AdminId";
          public          postgres    false    276                       1259    17404    AspNetRoles    TABLE     |   CREATE TABLE public."AspNetRoles" (
    "Id" character varying(128) NOT NULL,
    "Name" character varying(256) NOT NULL
);
 !   DROP TABLE public."AspNetRoles";
       public         heap    postgres    false                       1259    17409    AspNetUserRoles    TABLE     �   CREATE TABLE public."AspNetUserRoles" (
    "UserId" character varying(128) NOT NULL,
    "RoleId" character varying(128) NOT NULL
);
 %   DROP TABLE public."AspNetUserRoles";
       public         heap    postgres    false            �            1259    16921    AspNetUsers    TABLE     >  CREATE TABLE public."AspNetUsers" (
    "Id" character varying(128) NOT NULL,
    "UserName" character varying(256) NOT NULL,
    "PasswordHash" character varying,
    "Email" character varying(256),
    "PhoneNumber" character varying,
    "IP" character varying(20),
    "CreatedDate" timestamp without time zone
);
 !   DROP TABLE public."AspNetUsers";
       public         heap    postgres    false                       1259    17442    BlockRequests    TABLE     �  CREATE TABLE public."BlockRequests" (
    "BlockRequestId" integer NOT NULL,
    "PhoneNumber" character varying(50),
    "Email" character varying(50),
    "IsActive" bit(1),
    "Reason" character varying,
    "RequestId" character varying(50) NOT NULL,
    "IP" character varying(20),
    "CreatedDate" timestamp without time zone,
    "ModifiedDate" timestamp without time zone
);
 #   DROP TABLE public."BlockRequests";
       public         heap    postgres    false                       1259    17441     BlockRequests_BlockRequestId_seq    SEQUENCE     �   CREATE SEQUENCE public."BlockRequests_BlockRequestId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 9   DROP SEQUENCE public."BlockRequests_BlockRequestId_seq";
       public          postgres    false    263            �           0    0     BlockRequests_BlockRequestId_seq    SEQUENCE OWNED BY     k   ALTER SEQUENCE public."BlockRequests_BlockRequestId_seq" OWNED BY public."BlockRequests"."BlockRequestId";
          public          postgres    false    262            �            1259    17043    Business    TABLE     �  CREATE TABLE public."Business" (
    "BusinessId" integer NOT NULL,
    "Name" character varying(100) NOT NULL,
    "Address1" character varying(500),
    "Address2" character varying(500),
    "City" character varying(50),
    "RegionId" integer,
    "ZipCode" character varying(10),
    "PhoneNumber" character varying(20),
    "FaxNumber" character varying(20),
    "IsRegistered" bit(1),
    "CreatedBy" character varying(128),
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "Status" smallint,
    "IsDeleted" bit(1),
    "IP" character varying(20)
);
    DROP TABLE public."Business";
       public         heap    postgres    false            �            1259    17008    BusinessType    TABLE     y   CREATE TABLE public."BusinessType" (
    "BusinessTypeId" integer NOT NULL,
    "Name" character varying(50) NOT NULL
);
 "   DROP TABLE public."BusinessType";
       public         heap    postgres    false            �            1259    17007    BusinessType_BusinessTypeId_seq    SEQUENCE     �   CREATE SEQUENCE public."BusinessType_BusinessTypeId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 8   DROP SEQUENCE public."BusinessType_BusinessTypeId_seq";
       public          postgres    false    223            �           0    0    BusinessType_BusinessTypeId_seq    SEQUENCE OWNED BY     i   ALTER SEQUENCE public."BusinessType_BusinessTypeId_seq" OWNED BY public."BusinessType"."BusinessTypeId";
          public          postgres    false    222            �            1259    17042    Business_BusinessId_seq    SEQUENCE     �   CREATE SEQUENCE public."Business_BusinessId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 0   DROP SEQUENCE public."Business_BusinessId_seq";
       public          postgres    false    227            �           0    0    Business_BusinessId_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE public."Business_BusinessId_seq" OWNED BY public."Business"."BusinessId";
          public          postgres    false    226            	           1259    17451    CaseTag    TABLE     o   CREATE TABLE public."CaseTag" (
    "CaseTagId" integer NOT NULL,
    "Name" character varying(50) NOT NULL
);
    DROP TABLE public."CaseTag";
       public         heap    postgres    false                       1259    17450    CaseTag_CaseTagId_seq    SEQUENCE     �   CREATE SEQUENCE public."CaseTag_CaseTagId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public."CaseTag_CaseTagId_seq";
       public          postgres    false    265            �           0    0    CaseTag_CaseTagId_seq    SEQUENCE OWNED BY     U   ALTER SEQUENCE public."CaseTag_CaseTagId_seq" OWNED BY public."CaseTag"."CaseTagId";
          public          postgres    false    264            �            1259    17207 	   Concierge    TABLE     �  CREATE TABLE public."Concierge" (
    "ConciergeId" integer NOT NULL,
    "ConciergeName" character varying(100) NOT NULL,
    "Address" character varying(150),
    "Street" character varying(50) NOT NULL,
    "City" character varying(50) NOT NULL,
    "State" character varying(50) NOT NULL,
    "ZipCode" character varying(50) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "RegionId" integer,
    "IP" character varying(20)
);
    DROP TABLE public."Concierge";
       public         heap    postgres    false            �            1259    17206    Concierge_ConciergeId_seq    SEQUENCE     �   CREATE SEQUENCE public."Concierge_ConciergeId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 2   DROP SEQUENCE public."Concierge_ConciergeId_seq";
       public          postgres    false    237            �           0    0    Concierge_ConciergeId_seq    SEQUENCE OWNED BY     ]   ALTER SEQUENCE public."Concierge_ConciergeId_seq" OWNED BY public."Concierge"."ConciergeId";
          public          postgres    false    236                       1259    17677    EmailLog    TABLE     0  CREATE TABLE public."EmailLog" (
    "Id" bigint NOT NULL,
    "EmailTemplate" character varying NOT NULL,
    "SubjectName" character varying(200) NOT NULL,
    "EmailID" character varying(200) NOT NULL,
    "ConfirmationNumber" character varying(200),
    "FilePath" character varying,
    "RoleId" integer,
    "RequestId" integer,
    "AdminId" integer,
    "PhysicianId" integer,
    "CreateDate" timestamp without time zone NOT NULL,
    "SentDate" timestamp without time zone,
    "IsEmailSent" boolean,
    "SentTries" integer,
    "Action" integer
);
    DROP TABLE public."EmailLog";
       public         heap    postgres    false                       1259    17676    EmailLog_Id_seq    SEQUENCE     z   CREATE SEQUENCE public."EmailLog_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public."EmailLog_Id_seq";
       public          postgres    false    283            �           0    0    EmailLog_Id_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public."EmailLog_Id_seq" OWNED BY public."EmailLog"."Id";
          public          postgres    false    282                       1259    17652    EncounterForm    TABLE     �  CREATE TABLE public."EncounterForm" (
    "EncounterFormId" integer NOT NULL,
    "RequestId" integer,
    "HistoryOfPresentIllnessOrInjury" text,
    "MedicalHistory" text,
    "Medications" text,
    "Allergies" text,
    "Temp" text,
    "HR" text,
    "RR" text,
    "BloodPressureSystolic" text,
    "BloodPressureDiastolic" text,
    "O2" text,
    "Pain" text,
    "Heent" text,
    "CV" text,
    "Chest" text,
    "ABD" text,
    "Extremeties" text,
    "Skin" text,
    "Neuro" text,
    "Other" text,
    "Diagnosis" text,
    "TreatmentPlan" text,
    "MedicationsDispensed" text,
    "Procedures" text,
    "FollowUp" text,
    "AdminId" integer,
    "PhysicianId" integer,
    "IsFinalize" boolean DEFAULT false NOT NULL
);
 #   DROP TABLE public."EncounterForm";
       public         heap    postgres    false                       1259    17651 !   EncounterForm_EncounterFormId_seq    SEQUENCE     �   CREATE SEQUENCE public."EncounterForm_EncounterFormId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 :   DROP SEQUENCE public."EncounterForm_EncounterFormId_seq";
       public          postgres    false    281            �           0    0 !   EncounterForm_EncounterFormId_seq    SEQUENCE OWNED BY     m   ALTER SEQUENCE public."EncounterForm_EncounterFormId_seq" OWNED BY public."EncounterForm"."EncounterFormId";
          public          postgres    false    280                       1259    17465    HealthProfessionalType    TABLE     �   CREATE TABLE public."HealthProfessionalType" (
    "HealthProfessionalId" integer NOT NULL,
    "ProfessionName" character varying(50) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "IsActive" bit(1),
    "IsDeleted" bit(1)
);
 ,   DROP TABLE public."HealthProfessionalType";
       public         heap    postgres    false            
           1259    17464 /   HealthProfessionalType_HealthProfessionalId_seq    SEQUENCE     �   CREATE SEQUENCE public."HealthProfessionalType_HealthProfessionalId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 H   DROP SEQUENCE public."HealthProfessionalType_HealthProfessionalId_seq";
       public          postgres    false    267            �           0    0 /   HealthProfessionalType_HealthProfessionalId_seq    SEQUENCE OWNED BY     �   ALTER SEQUENCE public."HealthProfessionalType_HealthProfessionalId_seq" OWNED BY public."HealthProfessionalType"."HealthProfessionalId";
          public          postgres    false    266                       1259    17472    HealthProfessionals    TABLE     �  CREATE TABLE public."HealthProfessionals" (
    "VendorId" integer NOT NULL,
    "VendorName" character varying(100) NOT NULL,
    "Profession" integer,
    "FaxNumber" character varying(50) NOT NULL,
    "Address" character varying(150),
    "City" character varying(100),
    "State" character varying(50),
    "Zip" character varying(50),
    "RegionId" integer,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedDate" timestamp without time zone,
    "PhoneNumber" character varying(100),
    "IsDeleted" bit(1),
    "IP" character varying(20),
    "Email" character varying(50),
    "BusinessContact" character varying(100)
);
 )   DROP TABLE public."HealthProfessionals";
       public         heap    postgres    false                       1259    17471     HealthProfessionals_VendorId_seq    SEQUENCE     �   CREATE SEQUENCE public."HealthProfessionals_VendorId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 9   DROP SEQUENCE public."HealthProfessionals_VendorId_seq";
       public          postgres    false    269            �           0    0     HealthProfessionals_VendorId_seq    SEQUENCE OWNED BY     k   ALTER SEQUENCE public."HealthProfessionals_VendorId_seq" OWNED BY public."HealthProfessionals"."VendorId";
          public          postgres    false    268            �            1259    17311    Menu    TABLE     �   CREATE TABLE public."Menu" (
    "MenuId" integer NOT NULL,
    "Name" character varying(50) NOT NULL,
    "AccountType" smallint NOT NULL,
    "SortOrder" integer,
    CONSTRAINT "Menu_AccountType_check" CHECK (("AccountType" = ANY (ARRAY[1, 2])))
);
    DROP TABLE public."Menu";
       public         heap    postgres    false            �            1259    17310    Menu_MenuId_seq    SEQUENCE     �   CREATE SEQUENCE public."Menu_MenuId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public."Menu_MenuId_seq";
       public          postgres    false    249            �           0    0    Menu_MenuId_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public."Menu_MenuId_seq" OWNED BY public."Menu"."MenuId";
          public          postgres    false    248                       1259    17486    OrderDetails    TABLE     u  CREATE TABLE public."OrderDetails" (
    "Id" integer NOT NULL,
    "VendorId" integer,
    "RequestId" integer,
    "FaxNumber" character varying(50),
    "Email" character varying(50),
    "BusinessContact" character varying(100),
    "Prescription" text,
    "NoOfRefill" integer,
    "CreatedDate" timestamp without time zone,
    "CreatedBy" character varying(100)
);
 "   DROP TABLE public."OrderDetails";
       public         heap    postgres    false                       1259    17485    OrderDetails_Id_seq    SEQUENCE     �   CREATE SEQUENCE public."OrderDetails_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ,   DROP SEQUENCE public."OrderDetails_Id_seq";
       public          postgres    false    271            �           0    0    OrderDetails_Id_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public."OrderDetails_Id_seq" OWNED BY public."OrderDetails"."Id";
          public          postgres    false    270            #           1259    17751    PayRate    TABLE     n  CREATE TABLE public."PayRate" (
    "ID" integer NOT NULL,
    "PhysicianId" integer NOT NULL,
    "NightshiftWeekend" integer NOT NULL,
    "Shift" integer NOT NULL,
    "HousecallNightWeekend" integer NOT NULL,
    "PhoneConsults" integer NOT NULL,
    "PhoneNightWeekend" integer NOT NULL,
    "BatchTesting" integer NOT NULL,
    "HouseCall" integer NOT NULL
);
    DROP TABLE public."PayRate";
       public         heap    postgres    false            "           1259    17750    PayRate_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."PayRate_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public."PayRate_ID_seq";
       public          postgres    false    291            �           0    0    PayRate_ID_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public."PayRate_ID_seq" OWNED BY public."PayRate"."ID";
          public          postgres    false    290            �            1259    16951 	   Physician    TABLE       CREATE TABLE public."Physician" (
    "PhysicianId" integer NOT NULL,
    "AspNetUserId" character varying(128),
    "FirstName" character varying(100) NOT NULL,
    "LastName" character varying(100),
    "Email" character varying(50) NOT NULL,
    "Mobile" character varying(20),
    "MedicalLicense" character varying(500),
    "Photo" character varying(100),
    "AdminNotes" character varying(500),
    "IsAgreementDoc" bit(1),
    "IsBackgroundDoc" bit(1),
    "IsTrainingDoc" bit(1),
    "IsNonDisclosureDoc" bit(1),
    "Address1" character varying(500),
    "Address2" character varying(500),
    "City" character varying(100),
    "RegionId" integer,
    "Zip" character varying(10),
    "AltPhone" character varying(20),
    "CreatedBy" character varying(128),
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "Status" smallint,
    "BusinessName" character varying(100) NOT NULL,
    "BusinessWebsite" character varying(200) NOT NULL,
    "IsDeleted" bit(1),
    "RoleId" integer,
    "NPINumber" character varying(500),
    "IsLicenseDoc" bit(1),
    "Signature" character varying(100),
    "IsCredentialDoc" bit(1),
    "IsTokenGenerate" bit(1),
    "SyncEmailAddress" character varying(50)
);
    DROP TABLE public."Physician";
       public         heap    postgres    false            �            1259    16633    PhysicianLocation    TABLE     .  CREATE TABLE public."PhysicianLocation" (
    "LocationId" integer NOT NULL,
    "PhysicianId" integer NOT NULL,
    "Latitude" numeric(9,6),
    "Longitude" numeric(9,6),
    "CreatedDate" timestamp without time zone,
    "PhysicianName" character varying(50),
    "Address" character varying(500)
);
 '   DROP TABLE public."PhysicianLocation";
       public         heap    postgres    false            �            1259    16632     PhysicianLocation_LocationId_seq    SEQUENCE     �   CREATE SEQUENCE public."PhysicianLocation_LocationId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 9   DROP SEQUENCE public."PhysicianLocation_LocationId_seq";
       public          postgres    false    216            �           0    0     PhysicianLocation_LocationId_seq    SEQUENCE OWNED BY     k   ALTER SEQUENCE public."PhysicianLocation_LocationId_seq" OWNED BY public."PhysicianLocation"."LocationId";
          public          postgres    false    215                       1259    17512    PhysicianNotification    TABLE     �   CREATE TABLE public."PhysicianNotification" (
    id integer NOT NULL,
    "PhysicianId" integer NOT NULL,
    "IsNotificationStopped" bit(1)
);
 +   DROP TABLE public."PhysicianNotification";
       public         heap    postgres    false                       1259    17511    PhysicianNotification_id_seq    SEQUENCE     �   CREATE SEQUENCE public."PhysicianNotification_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 5   DROP SEQUENCE public."PhysicianNotification_id_seq";
       public          postgres    false    275            �           0    0    PhysicianNotification_id_seq    SEQUENCE OWNED BY     a   ALTER SEQUENCE public."PhysicianNotification_id_seq" OWNED BY public."PhysicianNotification".id;
          public          postgres    false    274                       1259    17495    PhysicianRegion    TABLE     �   CREATE TABLE public."PhysicianRegion" (
    "PhysicianRegionId" integer NOT NULL,
    "PhysicianId" integer NOT NULL,
    "RegionId" integer NOT NULL
);
 %   DROP TABLE public."PhysicianRegion";
       public         heap    postgres    false                       1259    17494 %   PhysicianRegion_PhysicianRegionId_seq    SEQUENCE     �   CREATE SEQUENCE public."PhysicianRegion_PhysicianRegionId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 >   DROP SEQUENCE public."PhysicianRegion_PhysicianRegionId_seq";
       public          postgres    false    273            �           0    0 %   PhysicianRegion_PhysicianRegionId_seq    SEQUENCE OWNED BY     u   ALTER SEQUENCE public."PhysicianRegion_PhysicianRegionId_seq" OWNED BY public."PhysicianRegion"."PhysicianRegionId";
          public          postgres    false    272            �            1259    16950    Physician_PhysicianId_seq    SEQUENCE     �   CREATE SEQUENCE public."Physician_PhysicianId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 2   DROP SEQUENCE public."Physician_PhysicianId_seq";
       public          postgres    false    219            �           0    0    Physician_PhysicianId_seq    SEQUENCE OWNED BY     ]   ALTER SEQUENCE public."Physician_PhysicianId_seq" OWNED BY public."Physician"."PhysicianId";
          public          postgres    false    218            %           1259    17816    Receipts    TABLE     =  CREATE TABLE public."Receipts" (
    "ID" integer NOT NULL,
    "TimeSheetId" integer NOT NULL,
    "PhysicianId" integer NOT NULL,
    "ItemName" character varying(128),
    "Amount" integer NOT NULL,
    "Date" timestamp without time zone NOT NULL,
    "IsDeleted" boolean,
    "Filename" character varying(128)
);
    DROP TABLE public."Receipts";
       public         heap    postgres    false            $           1259    17815    Receipts_ID_seq    SEQUENCE     �   CREATE SEQUENCE public."Receipts_ID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public."Receipts_ID_seq";
       public          postgres    false    293            �           0    0    Receipts_ID_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public."Receipts_ID_seq" OWNED BY public."Receipts"."ID";
          public          postgres    false    292            �            1259    17036    Region    TABLE     �   CREATE TABLE public."Region" (
    "RegionId" integer NOT NULL,
    "Name" character varying(50) NOT NULL,
    "Abbreviation" character varying(50)
);
    DROP TABLE public."Region";
       public         heap    postgres    false            �            1259    17035    Region_RegionId_seq    SEQUENCE     �   CREATE SEQUENCE public."Region_RegionId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ,   DROP SEQUENCE public."Region_RegionId_seq";
       public          postgres    false    225            �           0    0    Region_RegionId_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public."Region_RegionId_seq" OWNED BY public."Region"."RegionId";
          public          postgres    false    224            �            1259    16975    Request    TABLE     ,  CREATE TABLE public."Request" (
    "RequestId" integer NOT NULL,
    "RequestTypeId" integer NOT NULL,
    "UserId" integer,
    "FirstName" character varying(100),
    "LastName" character varying(100),
    "PhoneNumber" character varying(23),
    "Email" character varying(50),
    "Status" smallint NOT NULL,
    "PhysicianId" integer,
    "ConfirmationNumber" character varying(20),
    "CreatedDate" timestamp without time zone NOT NULL,
    "IsDeleted" bit(1),
    "ModifiedDate" timestamp without time zone,
    "DeclinedBy" character varying(250),
    "IsUrgentEmailSent" bit(1),
    "LastWellnessDate" timestamp without time zone,
    "IsMobile" bit(1),
    "CallType" smallint,
    "CompletedByPhysician" bit(1),
    "LastReservationDate" timestamp without time zone,
    "AcceptedDate" timestamp without time zone,
    "RelationName" character varying(100),
    "CaseNumber" character varying(50),
    "IP" character varying(20),
    "CaseTag" character varying(50),
    "CaseTagPhysician" character varying(50),
    "PatientAccountId" character varying(128),
    "CreatedUserId" integer,
    CONSTRAINT "Request_RequestTypeId_check" CHECK (("RequestTypeId" = ANY (ARRAY[1, 2, 3, 4]))),
    CONSTRAINT "Request_Status_check" CHECK (("Status" = ANY (ARRAY[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15])))
);
    DROP TABLE public."Request";
       public         heap    postgres    false            �            1259    17067    RequestBusiness    TABLE     �   CREATE TABLE public."RequestBusiness" (
    "RequestBusinessId" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "BusinessId" integer NOT NULL,
    "IP" character varying(20)
);
 %   DROP TABLE public."RequestBusiness";
       public         heap    postgres    false            �            1259    17066 %   RequestBusiness_RequestBusinessId_seq    SEQUENCE     �   CREATE SEQUENCE public."RequestBusiness_RequestBusinessId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 >   DROP SEQUENCE public."RequestBusiness_RequestBusinessId_seq";
       public          postgres    false    229            �           0    0 %   RequestBusiness_RequestBusinessId_seq    SEQUENCE OWNED BY     u   ALTER SEQUENCE public."RequestBusiness_RequestBusinessId_seq" OWNED BY public."RequestBusiness"."RequestBusinessId";
          public          postgres    false    228            �            1259    17084    RequestClient    TABLE     �  CREATE TABLE public."RequestClient" (
    "RequestClientId" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "FirstName" character varying(100) NOT NULL,
    "LastName" character varying(100),
    "PhoneNumber" character varying(23),
    "Location" character varying(100),
    "Address" character varying(500),
    "RegionId" integer,
    "NotiMobile" character varying(20),
    "NotiEmail" character varying(50),
    "Notes" character varying(500),
    "Email" character varying(50),
    "strMonth" character varying(20),
    "intYear" integer,
    "intDate" integer,
    "IsMobile" bit(1),
    "Street" character varying(100),
    "City" character varying(100),
    "State" character varying(100),
    "ZipCode" character varying(10),
    "CommunicationType" smallint,
    "RemindReservationCount" smallint,
    "RemindHouseCallCount" smallint,
    "IsSetFollowupSent" smallint,
    "IP" character varying(20),
    "IsReservationReminderSent" smallint,
    "Latitude" numeric(9,6),
    "Longitude" numeric(9,6)
);
 #   DROP TABLE public."RequestClient";
       public         heap    postgres    false            �            1259    17083 !   RequestClient_RequestClientId_seq    SEQUENCE     �   CREATE SEQUENCE public."RequestClient_RequestClientId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 :   DROP SEQUENCE public."RequestClient_RequestClientId_seq";
       public          postgres    false    231            �           0    0 !   RequestClient_RequestClientId_seq    SEQUENCE OWNED BY     m   ALTER SEQUENCE public."RequestClient_RequestClientId_seq" OWNED BY public."RequestClient"."RequestClientId";
          public          postgres    false    230            �            1259    17176    RequestClosed    TABLE       CREATE TABLE public."RequestClosed" (
    "RequestClosedId" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "RequestStatusLogId" integer NOT NULL,
    "PhyNotes" character varying(500),
    "ClientNotes" character varying(500),
    "IP" character varying(20)
);
 #   DROP TABLE public."RequestClosed";
       public         heap    postgres    false            �            1259    17175 !   RequestClosed_RequestClosedId_seq    SEQUENCE     �   CREATE SEQUENCE public."RequestClosed_RequestClosedId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 :   DROP SEQUENCE public."RequestClosed_RequestClosedId_seq";
       public          postgres    false    235            �           0    0 !   RequestClosed_RequestClosedId_seq    SEQUENCE OWNED BY     m   ALTER SEQUENCE public."RequestClosed_RequestClosedId_seq" OWNED BY public."RequestClosed"."RequestClosedId";
          public          postgres    false    234            �            1259    17219    RequestConcierge    TABLE     �   CREATE TABLE public."RequestConcierge" (
    "Id" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "ConciergeId" integer NOT NULL,
    "IP" character varying(20)
);
 &   DROP TABLE public."RequestConcierge";
       public         heap    postgres    false            �            1259    17218    RequestConcierge_Id_seq    SEQUENCE     �   CREATE SEQUENCE public."RequestConcierge_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 0   DROP SEQUENCE public."RequestConcierge_Id_seq";
       public          postgres    false    239            �           0    0    RequestConcierge_Id_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE public."RequestConcierge_Id_seq" OWNED BY public."RequestConcierge"."Id";
          public          postgres    false    238            �            1259    17236    RequestNotes    TABLE     .  CREATE TABLE public."RequestNotes" (
    "RequestNotesId" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "strMonth" character varying(20),
    "intYear" integer,
    "intDate" integer,
    "PhysicianNotes" character varying(500),
    "AdminNotes" character varying(500),
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "IP" character varying(20),
    "AdministrativeNotes" character varying(500)
);
 "   DROP TABLE public."RequestNotes";
       public         heap    postgres    false            �            1259    17235    RequestNotes_RequestNotesId_seq    SEQUENCE     �   CREATE SEQUENCE public."RequestNotes_RequestNotesId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 8   DROP SEQUENCE public."RequestNotes_RequestNotesId_seq";
       public          postgres    false    241            �           0    0    RequestNotes_RequestNotesId_seq    SEQUENCE OWNED BY     i   ALTER SEQUENCE public."RequestNotes_RequestNotesId_seq" OWNED BY public."RequestNotes"."RequestNotesId";
          public          postgres    false    240            �            1259    17147    RequestStatusLog    TABLE     �  CREATE TABLE public."RequestStatusLog" (
    "RequestStatusLogId" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "Status" smallint NOT NULL,
    "PhysicianId" integer,
    "AdminId" integer,
    "TransToPhysicianId" integer,
    "Notes" character varying(500),
    "CreatedDate" timestamp without time zone NOT NULL,
    "IP" character varying(20),
    "TransToAdmin" bit(1)
);
 &   DROP TABLE public."RequestStatusLog";
       public         heap    postgres    false            �            1259    17146 '   RequestStatusLog_RequestStatusLogId_seq    SEQUENCE     �   CREATE SEQUENCE public."RequestStatusLog_RequestStatusLogId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 @   DROP SEQUENCE public."RequestStatusLog_RequestStatusLogId_seq";
       public          postgres    false    233            �           0    0 '   RequestStatusLog_RequestStatusLogId_seq    SEQUENCE OWNED BY     y   ALTER SEQUENCE public."RequestStatusLog_RequestStatusLogId_seq" OWNED BY public."RequestStatusLog"."RequestStatusLogId";
          public          postgres    false    232            �            1259    17284    RequestType    TABLE     w   CREATE TABLE public."RequestType" (
    "RequestTypeId" integer NOT NULL,
    "Name" character varying(50) NOT NULL
);
 !   DROP TABLE public."RequestType";
       public         heap    postgres    false            �            1259    17283    RequestType_RequestTypeId_seq    SEQUENCE     �   CREATE SEQUENCE public."RequestType_RequestTypeId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 6   DROP SEQUENCE public."RequestType_RequestTypeId_seq";
       public          postgres    false    245            �           0    0    RequestType_RequestTypeId_seq    SEQUENCE OWNED BY     e   ALTER SEQUENCE public."RequestType_RequestTypeId_seq" OWNED BY public."RequestType"."RequestTypeId";
          public          postgres    false    244            �            1259    17260    RequestWiseFile    TABLE     �  CREATE TABLE public."RequestWiseFile" (
    "RequestWiseFileID" integer NOT NULL,
    "RequestId" integer NOT NULL,
    "FileName" character varying(500) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "PhysicianId" integer,
    "AdminId" integer,
    "DocType" smallint,
    "IsFrontSide" bit(1),
    "IsCompensation" bit(1),
    "IP" character varying(20),
    "IsFinalize" bit(1),
    "IsDeleted" bit(1),
    "IsPatientRecords" bit(1)
);
 %   DROP TABLE public."RequestWiseFile";
       public         heap    postgres    false            �            1259    17259 %   RequestWiseFile_RequestWiseFileID_seq    SEQUENCE     �   CREATE SEQUENCE public."RequestWiseFile_RequestWiseFileID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 >   DROP SEQUENCE public."RequestWiseFile_RequestWiseFileID_seq";
       public          postgres    false    243            �           0    0 %   RequestWiseFile_RequestWiseFileID_seq    SEQUENCE OWNED BY     u   ALTER SEQUENCE public."RequestWiseFile_RequestWiseFileID_seq" OWNED BY public."RequestWiseFile"."RequestWiseFileID";
          public          postgres    false    242            �            1259    16974    Request_RequestId_seq    SEQUENCE     �   CREATE SEQUENCE public."Request_RequestId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public."Request_RequestId_seq";
       public          postgres    false    221            �           0    0    Request_RequestId_seq    SEQUENCE OWNED BY     U   ALTER SEQUENCE public."Request_RequestId_seq" OWNED BY public."Request"."RequestId";
          public          postgres    false    220            �            1259    17291    Role    TABLE     �  CREATE TABLE public."Role" (
    "RoleId" integer NOT NULL,
    "Name" character varying(50) NOT NULL,
    "AccountType" smallint NOT NULL,
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "IsDeleted" bit(1) NOT NULL,
    "IP" character varying(20),
    CONSTRAINT "Role_AccountType_check" CHECK (("AccountType" = ANY (ARRAY[1, 2])))
);
    DROP TABLE public."Role";
       public         heap    postgres    false            �            1259    17319    RoleMenu    TABLE     �   CREATE TABLE public."RoleMenu" (
    "RoleMenuId" integer NOT NULL,
    "RoleId" integer NOT NULL,
    "MenuId" integer NOT NULL
);
    DROP TABLE public."RoleMenu";
       public         heap    postgres    false            �            1259    17318    RoleMenu_RoleMenuId_seq    SEQUENCE     �   CREATE SEQUENCE public."RoleMenu_RoleMenuId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 0   DROP SEQUENCE public."RoleMenu_RoleMenuId_seq";
       public          postgres    false    251            �           0    0    RoleMenu_RoleMenuId_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE public."RoleMenu_RoleMenuId_seq" OWNED BY public."RoleMenu"."RoleMenuId";
          public          postgres    false    250            �            1259    17290    Role_RoleId_seq    SEQUENCE     �   CREATE SEQUENCE public."Role_RoleId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public."Role_RoleId_seq";
       public          postgres    false    247            �           0    0    Role_RoleId_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public."Role_RoleId_seq" OWNED BY public."Role"."RoleId";
          public          postgres    false    246            �            1259    17336    Shift    TABLE     c  CREATE TABLE public."Shift" (
    "ShiftId" integer NOT NULL,
    "PhysicianId" integer NOT NULL,
    "StartDate" date NOT NULL,
    "IsRepeat" bit(1) NOT NULL,
    "WeekDays" character(7),
    "RepeatUpto" integer,
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "IP" character varying(20)
);
    DROP TABLE public."Shift";
       public         heap    postgres    false            �            1259    17353    ShiftDetail    TABLE     "  CREATE TABLE public."ShiftDetail" (
    "ShiftDetailId" integer NOT NULL,
    "ShiftId" integer NOT NULL,
    "ShiftDate" timestamp without time zone NOT NULL,
    "RegionId" integer,
    "StartTime" time without time zone NOT NULL,
    "EndTime" time without time zone NOT NULL,
    "Status" smallint NOT NULL,
    "IsDeleted" bit(1) NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "LastRunningDate" timestamp without time zone,
    "EventId" character varying(100),
    "IsSync" bit(1)
);
 !   DROP TABLE public."ShiftDetail";
       public         heap    postgres    false                       1259    17370    ShiftDetailRegion    TABLE     �   CREATE TABLE public."ShiftDetailRegion" (
    "ShiftDetailRegionId" integer NOT NULL,
    "ShiftDetailId" integer NOT NULL,
    "RegionId" integer NOT NULL,
    "IsDeleted" bit(1)
);
 '   DROP TABLE public."ShiftDetailRegion";
       public         heap    postgres    false                        1259    17369 )   ShiftDetailRegion_ShiftDetailRegionId_seq    SEQUENCE     �   CREATE SEQUENCE public."ShiftDetailRegion_ShiftDetailRegionId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 B   DROP SEQUENCE public."ShiftDetailRegion_ShiftDetailRegionId_seq";
       public          postgres    false    257            �           0    0 )   ShiftDetailRegion_ShiftDetailRegionId_seq    SEQUENCE OWNED BY     }   ALTER SEQUENCE public."ShiftDetailRegion_ShiftDetailRegionId_seq" OWNED BY public."ShiftDetailRegion"."ShiftDetailRegionId";
          public          postgres    false    256            �            1259    17352    ShiftDetail_ShiftDetailId_seq    SEQUENCE     �   CREATE SEQUENCE public."ShiftDetail_ShiftDetailId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 6   DROP SEQUENCE public."ShiftDetail_ShiftDetailId_seq";
       public          postgres    false    255            �           0    0    ShiftDetail_ShiftDetailId_seq    SEQUENCE OWNED BY     e   ALTER SEQUENCE public."ShiftDetail_ShiftDetailId_seq" OWNED BY public."ShiftDetail"."ShiftDetailId";
          public          postgres    false    254            �            1259    17335    Shift_ShiftId_seq    SEQUENCE     �   CREATE SEQUENCE public."Shift_ShiftId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public."Shift_ShiftId_seq";
       public          postgres    false    253            �           0    0    Shift_ShiftId_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public."Shift_ShiftId_seq" OWNED BY public."Shift"."ShiftId";
          public          postgres    false    252                       1259    17727 	   TimeSheet    TABLE     �  CREATE TABLE public."TimeSheet" (
    "TimeSheetID" integer NOT NULL,
    "PhysicianId" integer NOT NULL,
    "CreatedBy" character varying(128),
    "CreatedDate" timestamp without time zone NOT NULL,
    "StartDate" timestamp without time zone NOT NULL,
    "EndDate" timestamp without time zone NOT NULL,
    "Status" character varying(128),
    "IsFinalized" boolean,
    "Total" integer
);
    DROP TABLE public."TimeSheet";
       public         heap    postgres    false            !           1259    17739    TimeSheetDetails    TABLE     2  CREATE TABLE public."TimeSheetDetails" (
    "TimeSheetDetailID" integer NOT NULL,
    "TimeSheetId" integer NOT NULL,
    "OnCallHours" integer,
    "TotalHours" integer,
    "Holiday" boolean,
    "NoOfHouseCalls" integer,
    "NoOfPhoneCalls" integer,
    "Date" timestamp without time zone NOT NULL
);
 &   DROP TABLE public."TimeSheetDetails";
       public         heap    postgres    false                        1259    17738 &   TimeSheetDetails_TimeSheetDetailID_seq    SEQUENCE     �   CREATE SEQUENCE public."TimeSheetDetails_TimeSheetDetailID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ?   DROP SEQUENCE public."TimeSheetDetails_TimeSheetDetailID_seq";
       public          postgres    false    289            �           0    0 &   TimeSheetDetails_TimeSheetDetailID_seq    SEQUENCE OWNED BY     w   ALTER SEQUENCE public."TimeSheetDetails_TimeSheetDetailID_seq" OWNED BY public."TimeSheetDetails"."TimeSheetDetailID";
          public          postgres    false    288                       1259    17726    TimeSheet_TimeSheetID_seq    SEQUENCE     �   CREATE SEQUENCE public."TimeSheet_TimeSheetID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 2   DROP SEQUENCE public."TimeSheet_TimeSheetID_seq";
       public          postgres    false    287            �           0    0    TimeSheet_TimeSheetID_seq    SEQUENCE OWNED BY     ]   ALTER SEQUENCE public."TimeSheet_TimeSheetID_seq" OWNED BY public."TimeSheet"."TimeSheetID";
          public          postgres    false    286                       1259    17593    User    TABLE     W  CREATE TABLE public."User" (
    "UserId" integer NOT NULL,
    "AspNetUserId" character varying(128),
    "FirstName" character varying(100) NOT NULL,
    "LastName" character varying(100),
    "Email" character varying(50) NOT NULL,
    "Mobile" character varying(20),
    "IsMobile" bit(1),
    "Street" character varying(100),
    "City" character varying(100),
    "State" character varying(100),
    "RegionId" integer,
    "ZipCode" character varying(10),
    "strMonth" character varying(20),
    "intYear" integer,
    "intDate" integer,
    "CreatedBy" character varying(128) NOT NULL,
    "CreatedDate" timestamp without time zone NOT NULL,
    "ModifiedBy" character varying(128),
    "ModifiedDate" timestamp without time zone,
    "Status" smallint,
    "IsDeleted" bit(1),
    "IP" character varying(20),
    "IsRequestWithEmail" bit(1)
);
    DROP TABLE public."User";
       public         heap    postgres    false                       1259    17592    User_UserId_seq    SEQUENCE     �   CREATE SEQUENCE public."User_UserId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public."User_UserId_seq";
       public          postgres    false    279            �           0    0    User_UserId_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public."User_UserId_seq" OWNED BY public."User"."UserId";
          public          postgres    false    278                       1259    17686    smslog    TABLE     �  CREATE TABLE public.smslog (
    id bigint NOT NULL,
    smstemplate character varying NOT NULL,
    mobilenumber character varying(50) NOT NULL,
    confirmationnumber character varying(200),
    roleid integer,
    requestid integer,
    adminid integer,
    physicianid integer,
    createdate timestamp without time zone NOT NULL,
    sentdate timestamp without time zone,
    issmssent boolean,
    senttries integer NOT NULL,
    action integer
);
    DROP TABLE public.smslog;
       public         heap    postgres    false                       1259    17685    smslog_id_seq    SEQUENCE     v   CREATE SEQUENCE public.smslog_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 $   DROP SEQUENCE public.smslog_id_seq;
       public          postgres    false    285            �           0    0    smslog_id_seq    SEQUENCE OWNED BY     ?   ALTER SEQUENCE public.smslog_id_seq OWNED BY public.smslog.id;
          public          postgres    false    284            3           2604    17542    Admin AdminId    DEFAULT     t   ALTER TABLE ONLY public."Admin" ALTER COLUMN "AdminId" SET DEFAULT nextval('public."Admin_AdminId_seq"'::regclass);
 @   ALTER TABLE public."Admin" ALTER COLUMN "AdminId" DROP DEFAULT;
       public          postgres    false    276    277    277            +           2604    17428    AdminRegion AdminRegionId    DEFAULT     �   ALTER TABLE ONLY public."AdminRegion" ALTER COLUMN "AdminRegionId" SET DEFAULT nextval('public."AdminRegion_AdminRegionId_seq"'::regclass);
 L   ALTER TABLE public."AdminRegion" ALTER COLUMN "AdminRegionId" DROP DEFAULT;
       public          postgres    false    260    261    261            ,           2604    17445    BlockRequests BlockRequestId    DEFAULT     �   ALTER TABLE ONLY public."BlockRequests" ALTER COLUMN "BlockRequestId" SET DEFAULT nextval('public."BlockRequests_BlockRequestId_seq"'::regclass);
 O   ALTER TABLE public."BlockRequests" ALTER COLUMN "BlockRequestId" DROP DEFAULT;
       public          postgres    false    263    262    263                       2604    17046    Business BusinessId    DEFAULT     �   ALTER TABLE ONLY public."Business" ALTER COLUMN "BusinessId" SET DEFAULT nextval('public."Business_BusinessId_seq"'::regclass);
 F   ALTER TABLE public."Business" ALTER COLUMN "BusinessId" DROP DEFAULT;
       public          postgres    false    226    227    227                       2604    17011    BusinessType BusinessTypeId    DEFAULT     �   ALTER TABLE ONLY public."BusinessType" ALTER COLUMN "BusinessTypeId" SET DEFAULT nextval('public."BusinessType_BusinessTypeId_seq"'::regclass);
 N   ALTER TABLE public."BusinessType" ALTER COLUMN "BusinessTypeId" DROP DEFAULT;
       public          postgres    false    223    222    223            -           2604    17454    CaseTag CaseTagId    DEFAULT     |   ALTER TABLE ONLY public."CaseTag" ALTER COLUMN "CaseTagId" SET DEFAULT nextval('public."CaseTag_CaseTagId_seq"'::regclass);
 D   ALTER TABLE public."CaseTag" ALTER COLUMN "CaseTagId" DROP DEFAULT;
       public          postgres    false    264    265    265                        2604    17210    Concierge ConciergeId    DEFAULT     �   ALTER TABLE ONLY public."Concierge" ALTER COLUMN "ConciergeId" SET DEFAULT nextval('public."Concierge_ConciergeId_seq"'::regclass);
 H   ALTER TABLE public."Concierge" ALTER COLUMN "ConciergeId" DROP DEFAULT;
       public          postgres    false    237    236    237            7           2604    17680    EmailLog Id    DEFAULT     p   ALTER TABLE ONLY public."EmailLog" ALTER COLUMN "Id" SET DEFAULT nextval('public."EmailLog_Id_seq"'::regclass);
 >   ALTER TABLE public."EmailLog" ALTER COLUMN "Id" DROP DEFAULT;
       public          postgres    false    283    282    283            5           2604    17655    EncounterForm EncounterFormId    DEFAULT     �   ALTER TABLE ONLY public."EncounterForm" ALTER COLUMN "EncounterFormId" SET DEFAULT nextval('public."EncounterForm_EncounterFormId_seq"'::regclass);
 P   ALTER TABLE public."EncounterForm" ALTER COLUMN "EncounterFormId" DROP DEFAULT;
       public          postgres    false    280    281    281            .           2604    17468 +   HealthProfessionalType HealthProfessionalId    DEFAULT     �   ALTER TABLE ONLY public."HealthProfessionalType" ALTER COLUMN "HealthProfessionalId" SET DEFAULT nextval('public."HealthProfessionalType_HealthProfessionalId_seq"'::regclass);
 ^   ALTER TABLE public."HealthProfessionalType" ALTER COLUMN "HealthProfessionalId" DROP DEFAULT;
       public          postgres    false    267    266    267            /           2604    17475    HealthProfessionals VendorId    DEFAULT     �   ALTER TABLE ONLY public."HealthProfessionals" ALTER COLUMN "VendorId" SET DEFAULT nextval('public."HealthProfessionals_VendorId_seq"'::regclass);
 O   ALTER TABLE public."HealthProfessionals" ALTER COLUMN "VendorId" DROP DEFAULT;
       public          postgres    false    269    268    269            &           2604    17314    Menu MenuId    DEFAULT     p   ALTER TABLE ONLY public."Menu" ALTER COLUMN "MenuId" SET DEFAULT nextval('public."Menu_MenuId_seq"'::regclass);
 >   ALTER TABLE public."Menu" ALTER COLUMN "MenuId" DROP DEFAULT;
       public          postgres    false    248    249    249            0           2604    17489    OrderDetails Id    DEFAULT     x   ALTER TABLE ONLY public."OrderDetails" ALTER COLUMN "Id" SET DEFAULT nextval('public."OrderDetails_Id_seq"'::regclass);
 B   ALTER TABLE public."OrderDetails" ALTER COLUMN "Id" DROP DEFAULT;
       public          postgres    false    271    270    271            ;           2604    17754 
   PayRate ID    DEFAULT     n   ALTER TABLE ONLY public."PayRate" ALTER COLUMN "ID" SET DEFAULT nextval('public."PayRate_ID_seq"'::regclass);
 =   ALTER TABLE public."PayRate" ALTER COLUMN "ID" DROP DEFAULT;
       public          postgres    false    291    290    291                       2604    16954    Physician PhysicianId    DEFAULT     �   ALTER TABLE ONLY public."Physician" ALTER COLUMN "PhysicianId" SET DEFAULT nextval('public."Physician_PhysicianId_seq"'::regclass);
 H   ALTER TABLE public."Physician" ALTER COLUMN "PhysicianId" DROP DEFAULT;
       public          postgres    false    219    218    219                       2604    16636    PhysicianLocation LocationId    DEFAULT     �   ALTER TABLE ONLY public."PhysicianLocation" ALTER COLUMN "LocationId" SET DEFAULT nextval('public."PhysicianLocation_LocationId_seq"'::regclass);
 O   ALTER TABLE public."PhysicianLocation" ALTER COLUMN "LocationId" DROP DEFAULT;
       public          postgres    false    216    215    216            2           2604    17515    PhysicianNotification id    DEFAULT     �   ALTER TABLE ONLY public."PhysicianNotification" ALTER COLUMN id SET DEFAULT nextval('public."PhysicianNotification_id_seq"'::regclass);
 I   ALTER TABLE public."PhysicianNotification" ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    275    274    275            1           2604    17498 !   PhysicianRegion PhysicianRegionId    DEFAULT     �   ALTER TABLE ONLY public."PhysicianRegion" ALTER COLUMN "PhysicianRegionId" SET DEFAULT nextval('public."PhysicianRegion_PhysicianRegionId_seq"'::regclass);
 T   ALTER TABLE public."PhysicianRegion" ALTER COLUMN "PhysicianRegionId" DROP DEFAULT;
       public          postgres    false    273    272    273            <           2604    17819    Receipts ID    DEFAULT     p   ALTER TABLE ONLY public."Receipts" ALTER COLUMN "ID" SET DEFAULT nextval('public."Receipts_ID_seq"'::regclass);
 >   ALTER TABLE public."Receipts" ALTER COLUMN "ID" DROP DEFAULT;
       public          postgres    false    292    293    293                       2604    17039    Region RegionId    DEFAULT     x   ALTER TABLE ONLY public."Region" ALTER COLUMN "RegionId" SET DEFAULT nextval('public."Region_RegionId_seq"'::regclass);
 B   ALTER TABLE public."Region" ALTER COLUMN "RegionId" DROP DEFAULT;
       public          postgres    false    224    225    225                       2604    16978    Request RequestId    DEFAULT     |   ALTER TABLE ONLY public."Request" ALTER COLUMN "RequestId" SET DEFAULT nextval('public."Request_RequestId_seq"'::regclass);
 D   ALTER TABLE public."Request" ALTER COLUMN "RequestId" DROP DEFAULT;
       public          postgres    false    221    220    221                       2604    17070 !   RequestBusiness RequestBusinessId    DEFAULT     �   ALTER TABLE ONLY public."RequestBusiness" ALTER COLUMN "RequestBusinessId" SET DEFAULT nextval('public."RequestBusiness_RequestBusinessId_seq"'::regclass);
 T   ALTER TABLE public."RequestBusiness" ALTER COLUMN "RequestBusinessId" DROP DEFAULT;
       public          postgres    false    229    228    229                       2604    17087    RequestClient RequestClientId    DEFAULT     �   ALTER TABLE ONLY public."RequestClient" ALTER COLUMN "RequestClientId" SET DEFAULT nextval('public."RequestClient_RequestClientId_seq"'::regclass);
 P   ALTER TABLE public."RequestClient" ALTER COLUMN "RequestClientId" DROP DEFAULT;
       public          postgres    false    231    230    231                       2604    17179    RequestClosed RequestClosedId    DEFAULT     �   ALTER TABLE ONLY public."RequestClosed" ALTER COLUMN "RequestClosedId" SET DEFAULT nextval('public."RequestClosed_RequestClosedId_seq"'::regclass);
 P   ALTER TABLE public."RequestClosed" ALTER COLUMN "RequestClosedId" DROP DEFAULT;
       public          postgres    false    235    234    235            !           2604    17222    RequestConcierge Id    DEFAULT     �   ALTER TABLE ONLY public."RequestConcierge" ALTER COLUMN "Id" SET DEFAULT nextval('public."RequestConcierge_Id_seq"'::regclass);
 F   ALTER TABLE public."RequestConcierge" ALTER COLUMN "Id" DROP DEFAULT;
       public          postgres    false    239    238    239            "           2604    17239    RequestNotes RequestNotesId    DEFAULT     �   ALTER TABLE ONLY public."RequestNotes" ALTER COLUMN "RequestNotesId" SET DEFAULT nextval('public."RequestNotes_RequestNotesId_seq"'::regclass);
 N   ALTER TABLE public."RequestNotes" ALTER COLUMN "RequestNotesId" DROP DEFAULT;
       public          postgres    false    240    241    241                       2604    17150 #   RequestStatusLog RequestStatusLogId    DEFAULT     �   ALTER TABLE ONLY public."RequestStatusLog" ALTER COLUMN "RequestStatusLogId" SET DEFAULT nextval('public."RequestStatusLog_RequestStatusLogId_seq"'::regclass);
 V   ALTER TABLE public."RequestStatusLog" ALTER COLUMN "RequestStatusLogId" DROP DEFAULT;
       public          postgres    false    233    232    233            $           2604    17287    RequestType RequestTypeId    DEFAULT     �   ALTER TABLE ONLY public."RequestType" ALTER COLUMN "RequestTypeId" SET DEFAULT nextval('public."RequestType_RequestTypeId_seq"'::regclass);
 L   ALTER TABLE public."RequestType" ALTER COLUMN "RequestTypeId" DROP DEFAULT;
       public          postgres    false    244    245    245            #           2604    17263 !   RequestWiseFile RequestWiseFileID    DEFAULT     �   ALTER TABLE ONLY public."RequestWiseFile" ALTER COLUMN "RequestWiseFileID" SET DEFAULT nextval('public."RequestWiseFile_RequestWiseFileID_seq"'::regclass);
 T   ALTER TABLE public."RequestWiseFile" ALTER COLUMN "RequestWiseFileID" DROP DEFAULT;
       public          postgres    false    243    242    243            %           2604    17294    Role RoleId    DEFAULT     p   ALTER TABLE ONLY public."Role" ALTER COLUMN "RoleId" SET DEFAULT nextval('public."Role_RoleId_seq"'::regclass);
 >   ALTER TABLE public."Role" ALTER COLUMN "RoleId" DROP DEFAULT;
       public          postgres    false    247    246    247            '           2604    17322    RoleMenu RoleMenuId    DEFAULT     �   ALTER TABLE ONLY public."RoleMenu" ALTER COLUMN "RoleMenuId" SET DEFAULT nextval('public."RoleMenu_RoleMenuId_seq"'::regclass);
 F   ALTER TABLE public."RoleMenu" ALTER COLUMN "RoleMenuId" DROP DEFAULT;
       public          postgres    false    250    251    251            (           2604    17339    Shift ShiftId    DEFAULT     t   ALTER TABLE ONLY public."Shift" ALTER COLUMN "ShiftId" SET DEFAULT nextval('public."Shift_ShiftId_seq"'::regclass);
 @   ALTER TABLE public."Shift" ALTER COLUMN "ShiftId" DROP DEFAULT;
       public          postgres    false    253    252    253            )           2604    17356    ShiftDetail ShiftDetailId    DEFAULT     �   ALTER TABLE ONLY public."ShiftDetail" ALTER COLUMN "ShiftDetailId" SET DEFAULT nextval('public."ShiftDetail_ShiftDetailId_seq"'::regclass);
 L   ALTER TABLE public."ShiftDetail" ALTER COLUMN "ShiftDetailId" DROP DEFAULT;
       public          postgres    false    254    255    255            *           2604    17373 %   ShiftDetailRegion ShiftDetailRegionId    DEFAULT     �   ALTER TABLE ONLY public."ShiftDetailRegion" ALTER COLUMN "ShiftDetailRegionId" SET DEFAULT nextval('public."ShiftDetailRegion_ShiftDetailRegionId_seq"'::regclass);
 X   ALTER TABLE public."ShiftDetailRegion" ALTER COLUMN "ShiftDetailRegionId" DROP DEFAULT;
       public          postgres    false    257    256    257            9           2604    17730    TimeSheet TimeSheetID    DEFAULT     �   ALTER TABLE ONLY public."TimeSheet" ALTER COLUMN "TimeSheetID" SET DEFAULT nextval('public."TimeSheet_TimeSheetID_seq"'::regclass);
 H   ALTER TABLE public."TimeSheet" ALTER COLUMN "TimeSheetID" DROP DEFAULT;
       public          postgres    false    286    287    287            :           2604    17742 "   TimeSheetDetails TimeSheetDetailID    DEFAULT     �   ALTER TABLE ONLY public."TimeSheetDetails" ALTER COLUMN "TimeSheetDetailID" SET DEFAULT nextval('public."TimeSheetDetails_TimeSheetDetailID_seq"'::regclass);
 U   ALTER TABLE public."TimeSheetDetails" ALTER COLUMN "TimeSheetDetailID" DROP DEFAULT;
       public          postgres    false    288    289    289            4           2604    17596    User UserId    DEFAULT     p   ALTER TABLE ONLY public."User" ALTER COLUMN "UserId" SET DEFAULT nextval('public."User_UserId_seq"'::regclass);
 >   ALTER TABLE public."User" ALTER COLUMN "UserId" DROP DEFAULT;
       public          postgres    false    279    278    279            8           2604    17689 	   smslog id    DEFAULT     f   ALTER TABLE ONLY public.smslog ALTER COLUMN id SET DEFAULT nextval('public.smslog_id_seq'::regclass);
 8   ALTER TABLE public.smslog ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    284    285    285            �          0    17539    Admin 
   TABLE DATA             COPY public."Admin" ("AdminId", "AspNetUserId", "FirstName", "LastName", "Email", "Mobile", "Address1", "Address2", "City", "RegionId", "Zip", "AltPhone", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "IsDeleted", "RoleId") FROM stdin;
    public          postgres    false    277   �      �          0    17425    AdminRegion 
   TABLE DATA           O   COPY public."AdminRegion" ("AdminRegionId", "AdminId", "RegionId") FROM stdin;
    public          postgres    false    261   6�      �          0    17404    AspNetRoles 
   TABLE DATA           5   COPY public."AspNetRoles" ("Id", "Name") FROM stdin;
    public          postgres    false    258   w�      �          0    17409    AspNetUserRoles 
   TABLE DATA           ?   COPY public."AspNetUserRoles" ("UserId", "RoleId") FROM stdin;
    public          postgres    false    259   ��      Y          0    16921    AspNetUsers 
   TABLE DATA           v   COPY public."AspNetUsers" ("Id", "UserName", "PasswordHash", "Email", "PhoneNumber", "IP", "CreatedDate") FROM stdin;
    public          postgres    false    217    �      �          0    17442    BlockRequests 
   TABLE DATA           �   COPY public."BlockRequests" ("BlockRequestId", "PhoneNumber", "Email", "IsActive", "Reason", "RequestId", "IP", "CreatedDate", "ModifiedDate") FROM stdin;
    public          postgres    false    263   ��      c          0    17043    Business 
   TABLE DATA           �   COPY public."Business" ("BusinessId", "Name", "Address1", "Address2", "City", "RegionId", "ZipCode", "PhoneNumber", "FaxNumber", "IsRegistered", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "IsDeleted", "IP") FROM stdin;
    public          postgres    false    227   ��      _          0    17008    BusinessType 
   TABLE DATA           B   COPY public."BusinessType" ("BusinessTypeId", "Name") FROM stdin;
    public          postgres    false    223   ��      �          0    17451    CaseTag 
   TABLE DATA           8   COPY public."CaseTag" ("CaseTagId", "Name") FROM stdin;
    public          postgres    false    265   ��      m          0    17207 	   Concierge 
   TABLE DATA           �   COPY public."Concierge" ("ConciergeId", "ConciergeName", "Address", "Street", "City", "State", "ZipCode", "CreatedDate", "RegionId", "IP") FROM stdin;
    public          postgres    false    237   ��      �          0    17677    EmailLog 
   TABLE DATA           �   COPY public."EmailLog" ("Id", "EmailTemplate", "SubjectName", "EmailID", "ConfirmationNumber", "FilePath", "RoleId", "RequestId", "AdminId", "PhysicianId", "CreateDate", "SentDate", "IsEmailSent", "SentTries", "Action") FROM stdin;
    public          postgres    false    283   ��      �          0    17652    EncounterForm 
   TABLE DATA           �  COPY public."EncounterForm" ("EncounterFormId", "RequestId", "HistoryOfPresentIllnessOrInjury", "MedicalHistory", "Medications", "Allergies", "Temp", "HR", "RR", "BloodPressureSystolic", "BloodPressureDiastolic", "O2", "Pain", "Heent", "CV", "Chest", "ABD", "Extremeties", "Skin", "Neuro", "Other", "Diagnosis", "TreatmentPlan", "MedicationsDispensed", "Procedures", "FollowUp", "AdminId", "PhysicianId", "IsFinalize") FROM stdin;
    public          postgres    false    281   ��      �          0    17465    HealthProfessionalType 
   TABLE DATA           �   COPY public."HealthProfessionalType" ("HealthProfessionalId", "ProfessionName", "CreatedDate", "IsActive", "IsDeleted") FROM stdin;
    public          postgres    false    267   4�      �          0    17472    HealthProfessionals 
   TABLE DATA           �   COPY public."HealthProfessionals" ("VendorId", "VendorName", "Profession", "FaxNumber", "Address", "City", "State", "Zip", "RegionId", "CreatedDate", "ModifiedDate", "PhoneNumber", "IsDeleted", "IP", "Email", "BusinessContact") FROM stdin;
    public          postgres    false    269   z�      y          0    17311    Menu 
   TABLE DATA           N   COPY public."Menu" ("MenuId", "Name", "AccountType", "SortOrder") FROM stdin;
    public          postgres    false    249   z�      �          0    17486    OrderDetails 
   TABLE DATA           �   COPY public."OrderDetails" ("Id", "VendorId", "RequestId", "FaxNumber", "Email", "BusinessContact", "Prescription", "NoOfRefill", "CreatedDate", "CreatedBy") FROM stdin;
    public          postgres    false    271   ��      �          0    17751    PayRate 
   TABLE DATA           �   COPY public."PayRate" ("ID", "PhysicianId", "NightshiftWeekend", "Shift", "HousecallNightWeekend", "PhoneConsults", "PhoneNightWeekend", "BatchTesting", "HouseCall") FROM stdin;
    public          postgres    false    291   J�      [          0    16951 	   Physician 
   TABLE DATA             COPY public."Physician" ("PhysicianId", "AspNetUserId", "FirstName", "LastName", "Email", "Mobile", "MedicalLicense", "Photo", "AdminNotes", "IsAgreementDoc", "IsBackgroundDoc", "IsTrainingDoc", "IsNonDisclosureDoc", "Address1", "Address2", "City", "RegionId", "Zip", "AltPhone", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "BusinessName", "BusinessWebsite", "IsDeleted", "RoleId", "NPINumber", "IsLicenseDoc", "Signature", "IsCredentialDoc", "IsTokenGenerate", "SyncEmailAddress") FROM stdin;
    public          postgres    false    219   ��      X          0    16633    PhysicianLocation 
   TABLE DATA           �   COPY public."PhysicianLocation" ("LocationId", "PhysicianId", "Latitude", "Longitude", "CreatedDate", "PhysicianName", "Address") FROM stdin;
    public          postgres    false    216   +�      �          0    17512    PhysicianNotification 
   TABLE DATA           ]   COPY public."PhysicianNotification" (id, "PhysicianId", "IsNotificationStopped") FROM stdin;
    public          postgres    false    275   ��      �          0    17495    PhysicianRegion 
   TABLE DATA           [   COPY public."PhysicianRegion" ("PhysicianRegionId", "PhysicianId", "RegionId") FROM stdin;
    public          postgres    false    273   ��      �          0    17816    Receipts 
   TABLE DATA              COPY public."Receipts" ("ID", "TimeSheetId", "PhysicianId", "ItemName", "Amount", "Date", "IsDeleted", "Filename") FROM stdin;
    public          postgres    false    293   )�      a          0    17036    Region 
   TABLE DATA           F   COPY public."Region" ("RegionId", "Name", "Abbreviation") FROM stdin;
    public          postgres    false    225   �      ]          0    16975    Request 
   TABLE DATA           �  COPY public."Request" ("RequestId", "RequestTypeId", "UserId", "FirstName", "LastName", "PhoneNumber", "Email", "Status", "PhysicianId", "ConfirmationNumber", "CreatedDate", "IsDeleted", "ModifiedDate", "DeclinedBy", "IsUrgentEmailSent", "LastWellnessDate", "IsMobile", "CallType", "CompletedByPhysician", "LastReservationDate", "AcceptedDate", "RelationName", "CaseNumber", "IP", "CaseTag", "CaseTagPhysician", "PatientAccountId", "CreatedUserId") FROM stdin;
    public          postgres    false    221   n�      e          0    17067    RequestBusiness 
   TABLE DATA           a   COPY public."RequestBusiness" ("RequestBusinessId", "RequestId", "BusinessId", "IP") FROM stdin;
    public          postgres    false    229   �      g          0    17084    RequestClient 
   TABLE DATA           �  COPY public."RequestClient" ("RequestClientId", "RequestId", "FirstName", "LastName", "PhoneNumber", "Location", "Address", "RegionId", "NotiMobile", "NotiEmail", "Notes", "Email", "strMonth", "intYear", "intDate", "IsMobile", "Street", "City", "State", "ZipCode", "CommunicationType", "RemindReservationCount", "RemindHouseCallCount", "IsSetFollowupSent", "IP", "IsReservationReminderSent", "Latitude", "Longitude") FROM stdin;
    public          postgres    false    231   e�      k          0    17176    RequestClosed 
   TABLE DATA           �   COPY public."RequestClosed" ("RequestClosedId", "RequestId", "RequestStatusLogId", "PhyNotes", "ClientNotes", "IP") FROM stdin;
    public          postgres    false    235   ��      o          0    17219    RequestConcierge 
   TABLE DATA           T   COPY public."RequestConcierge" ("Id", "RequestId", "ConciergeId", "IP") FROM stdin;
    public          postgres    false    239   �      q          0    17236    RequestNotes 
   TABLE DATA           �   COPY public."RequestNotes" ("RequestNotesId", "RequestId", "strMonth", "intYear", "intDate", "PhysicianNotes", "AdminNotes", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "IP", "AdministrativeNotes") FROM stdin;
    public          postgres    false    241   5�      i          0    17147    RequestStatusLog 
   TABLE DATA           �   COPY public."RequestStatusLog" ("RequestStatusLogId", "RequestId", "Status", "PhysicianId", "AdminId", "TransToPhysicianId", "Notes", "CreatedDate", "IP", "TransToAdmin") FROM stdin;
    public          postgres    false    233   �      u          0    17284    RequestType 
   TABLE DATA           @   COPY public."RequestType" ("RequestTypeId", "Name") FROM stdin;
    public          postgres    false    245   `      s          0    17260    RequestWiseFile 
   TABLE DATA           �   COPY public."RequestWiseFile" ("RequestWiseFileID", "RequestId", "FileName", "CreatedDate", "PhysicianId", "AdminId", "DocType", "IsFrontSide", "IsCompensation", "IP", "IsFinalize", "IsDeleted", "IsPatientRecords") FROM stdin;
    public          postgres    false    243   }      w          0    17291    Role 
   TABLE DATA           �   COPY public."Role" ("RoleId", "Name", "AccountType", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "IsDeleted", "IP") FROM stdin;
    public          postgres    false    247   �      {          0    17319    RoleMenu 
   TABLE DATA           F   COPY public."RoleMenu" ("RoleMenuId", "RoleId", "MenuId") FROM stdin;
    public          postgres    false    251   '	      }          0    17336    Shift 
   TABLE DATA           �   COPY public."Shift" ("ShiftId", "PhysicianId", "StartDate", "IsRepeat", "WeekDays", "RepeatUpto", "CreatedBy", "CreatedDate", "IP") FROM stdin;
    public          postgres    false    253   �	                0    17353    ShiftDetail 
   TABLE DATA           �   COPY public."ShiftDetail" ("ShiftDetailId", "ShiftId", "ShiftDate", "RegionId", "StartTime", "EndTime", "Status", "IsDeleted", "ModifiedBy", "ModifiedDate", "LastRunningDate", "EventId", "IsSync") FROM stdin;
    public          postgres    false    255   �      �          0    17370    ShiftDetailRegion 
   TABLE DATA           n   COPY public."ShiftDetailRegion" ("ShiftDetailRegionId", "ShiftDetailId", "RegionId", "IsDeleted") FROM stdin;
    public          postgres    false    257   �      �          0    17727 	   TimeSheet 
   TABLE DATA           �   COPY public."TimeSheet" ("TimeSheetID", "PhysicianId", "CreatedBy", "CreatedDate", "StartDate", "EndDate", "Status", "IsFinalized", "Total") FROM stdin;
    public          postgres    false    287   �      �          0    17739    TimeSheetDetails 
   TABLE DATA           �   COPY public."TimeSheetDetails" ("TimeSheetDetailID", "TimeSheetId", "OnCallHours", "TotalHours", "Holiday", "NoOfHouseCalls", "NoOfPhoneCalls", "Date") FROM stdin;
    public          postgres    false    289   |      �          0    17593    User 
   TABLE DATA           3  COPY public."User" ("UserId", "AspNetUserId", "FirstName", "LastName", "Email", "Mobile", "IsMobile", "Street", "City", "State", "RegionId", "ZipCode", "strMonth", "intYear", "intDate", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Status", "IsDeleted", "IP", "IsRequestWithEmail") FROM stdin;
    public          postgres    false    279   �      �          0    17686    smslog 
   TABLE DATA           �   COPY public.smslog (id, smstemplate, mobilenumber, confirmationnumber, roleid, requestid, adminid, physicianid, createdate, sentdate, issmssent, senttries, action) FROM stdin;
    public          postgres    false    285   �      �           0    0    AdminRegion_AdminRegionId_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('public."AdminRegion_AdminRegionId_seq"', 11, true);
          public          postgres    false    260            �           0    0    Admin_AdminId_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public."Admin_AdminId_seq"', 4, true);
          public          postgres    false    276            �           0    0     BlockRequests_BlockRequestId_seq    SEQUENCE SET     P   SELECT pg_catalog.setval('public."BlockRequests_BlockRequestId_seq"', 8, true);
          public          postgres    false    262            �           0    0    BusinessType_BusinessTypeId_seq    SEQUENCE SET     P   SELECT pg_catalog.setval('public."BusinessType_BusinessTypeId_seq"', 1, false);
          public          postgres    false    222            �           0    0    Business_BusinessId_seq    SEQUENCE SET     G   SELECT pg_catalog.setval('public."Business_BusinessId_seq"', 7, true);
          public          postgres    false    226            �           0    0    CaseTag_CaseTagId_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public."CaseTag_CaseTagId_seq"', 1, false);
          public          postgres    false    264            �           0    0    Concierge_ConciergeId_seq    SEQUENCE SET     J   SELECT pg_catalog.setval('public."Concierge_ConciergeId_seq"', 16, true);
          public          postgres    false    236            �           0    0    EmailLog_Id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."EmailLog_Id_seq"', 27, true);
          public          postgres    false    282            �           0    0 !   EncounterForm_EncounterFormId_seq    SEQUENCE SET     Q   SELECT pg_catalog.setval('public."EncounterForm_EncounterFormId_seq"', 3, true);
          public          postgres    false    280            �           0    0 /   HealthProfessionalType_HealthProfessionalId_seq    SEQUENCE SET     _   SELECT pg_catalog.setval('public."HealthProfessionalType_HealthProfessionalId_seq"', 1, true);
          public          postgres    false    266            �           0    0     HealthProfessionals_VendorId_seq    SEQUENCE SET     P   SELECT pg_catalog.setval('public."HealthProfessionals_VendorId_seq"', 6, true);
          public          postgres    false    268            �           0    0    Menu_MenuId_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."Menu_MenuId_seq"', 33, true);
          public          postgres    false    248            �           0    0    OrderDetails_Id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public."OrderDetails_Id_seq"', 2, true);
          public          postgres    false    270            �           0    0    PayRate_ID_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public."PayRate_ID_seq"', 2, true);
          public          postgres    false    290            �           0    0     PhysicianLocation_LocationId_seq    SEQUENCE SET     P   SELECT pg_catalog.setval('public."PhysicianLocation_LocationId_seq"', 3, true);
          public          postgres    false    215            �           0    0    PhysicianNotification_id_seq    SEQUENCE SET     L   SELECT pg_catalog.setval('public."PhysicianNotification_id_seq"', 4, true);
          public          postgres    false    274            �           0    0 %   PhysicianRegion_PhysicianRegionId_seq    SEQUENCE SET     U   SELECT pg_catalog.setval('public."PhysicianRegion_PhysicianRegionId_seq"', 8, true);
          public          postgres    false    272            �           0    0    Physician_PhysicianId_seq    SEQUENCE SET     I   SELECT pg_catalog.setval('public."Physician_PhysicianId_seq"', 4, true);
          public          postgres    false    218            �           0    0    Receipts_ID_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public."Receipts_ID_seq"', 4, true);
          public          postgres    false    292            �           0    0    Region_RegionId_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public."Region_RegionId_seq"', 5, true);
          public          postgres    false    224            �           0    0 %   RequestBusiness_RequestBusinessId_seq    SEQUENCE SET     U   SELECT pg_catalog.setval('public."RequestBusiness_RequestBusinessId_seq"', 6, true);
          public          postgres    false    228            �           0    0 !   RequestClient_RequestClientId_seq    SEQUENCE SET     R   SELECT pg_catalog.setval('public."RequestClient_RequestClientId_seq"', 75, true);
          public          postgres    false    230            �           0    0 !   RequestClosed_RequestClosedId_seq    SEQUENCE SET     R   SELECT pg_catalog.setval('public."RequestClosed_RequestClosedId_seq"', 11, true);
          public          postgres    false    234            �           0    0    RequestConcierge_Id_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public."RequestConcierge_Id_seq"', 1, false);
          public          postgres    false    238            �           0    0    RequestNotes_RequestNotesId_seq    SEQUENCE SET     P   SELECT pg_catalog.setval('public."RequestNotes_RequestNotesId_seq"', 13, true);
          public          postgres    false    240            �           0    0 '   RequestStatusLog_RequestStatusLogId_seq    SEQUENCE SET     X   SELECT pg_catalog.setval('public."RequestStatusLog_RequestStatusLogId_seq"', 83, true);
          public          postgres    false    232            �           0    0    RequestType_RequestTypeId_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('public."RequestType_RequestTypeId_seq"', 1, false);
          public          postgres    false    244            �           0    0 %   RequestWiseFile_RequestWiseFileID_seq    SEQUENCE SET     V   SELECT pg_catalog.setval('public."RequestWiseFile_RequestWiseFileID_seq"', 52, true);
          public          postgres    false    242            �           0    0    Request_RequestId_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public."Request_RequestId_seq"', 69, true);
          public          postgres    false    220            �           0    0    RoleMenu_RoleMenuId_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public."RoleMenu_RoleMenuId_seq"', 66, true);
          public          postgres    false    250            �           0    0    Role_RoleId_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public."Role_RoleId_seq"', 8, true);
          public          postgres    false    246            �           0    0 )   ShiftDetailRegion_ShiftDetailRegionId_seq    SEQUENCE SET     Z   SELECT pg_catalog.setval('public."ShiftDetailRegion_ShiftDetailRegionId_seq"', 10, true);
          public          postgres    false    256            �           0    0    ShiftDetail_ShiftDetailId_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('public."ShiftDetail_ShiftDetailId_seq"', 43, true);
          public          postgres    false    254            �           0    0    Shift_ShiftId_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public."Shift_ShiftId_seq"', 37, true);
          public          postgres    false    252            �           0    0 &   TimeSheetDetails_TimeSheetDetailID_seq    SEQUENCE SET     W   SELECT pg_catalog.setval('public."TimeSheetDetails_TimeSheetDetailID_seq"', 56, true);
          public          postgres    false    288            �           0    0    TimeSheet_TimeSheetID_seq    SEQUENCE SET     I   SELECT pg_catalog.setval('public."TimeSheet_TimeSheetID_seq"', 4, true);
          public          postgres    false    286            �           0    0    User_UserId_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public."User_UserId_seq"', 32, true);
          public          postgres    false    278            �           0    0    smslog_id_seq    SEQUENCE SET     ;   SELECT pg_catalog.setval('public.smslog_id_seq', 2, true);
          public          postgres    false    284            r           2606    17430    AdminRegion AdminRegion_pkey 
   CONSTRAINT     k   ALTER TABLE ONLY public."AdminRegion"
    ADD CONSTRAINT "AdminRegion_pkey" PRIMARY KEY ("AdminRegionId");
 J   ALTER TABLE ONLY public."AdminRegion" DROP CONSTRAINT "AdminRegion_pkey";
       public            postgres    false    261            �           2606    17546    Admin Admin_pkey 
   CONSTRAINT     Y   ALTER TABLE ONLY public."Admin"
    ADD CONSTRAINT "Admin_pkey" PRIMARY KEY ("AdminId");
 >   ALTER TABLE ONLY public."Admin" DROP CONSTRAINT "Admin_pkey";
       public            postgres    false    277            n           2606    17408    AspNetRoles AspNetRoles_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public."AspNetRoles"
    ADD CONSTRAINT "AspNetRoles_pkey" PRIMARY KEY ("Id");
 J   ALTER TABLE ONLY public."AspNetRoles" DROP CONSTRAINT "AspNetRoles_pkey";
       public            postgres    false    258            p           2606    17413 $   AspNetUserRoles AspNetUserRoles_pkey 
   CONSTRAINT     v   ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "AspNetUserRoles_pkey" PRIMARY KEY ("UserId", "RoleId");
 R   ALTER TABLE ONLY public."AspNetUserRoles" DROP CONSTRAINT "AspNetUserRoles_pkey";
       public            postgres    false    259    259            D           2606    16927    AspNetUsers AspNetUsers_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public."AspNetUsers"
    ADD CONSTRAINT "AspNetUsers_pkey" PRIMARY KEY ("Id");
 J   ALTER TABLE ONLY public."AspNetUsers" DROP CONSTRAINT "AspNetUsers_pkey";
       public            postgres    false    217            t           2606    17449     BlockRequests BlockRequests_pkey 
   CONSTRAINT     p   ALTER TABLE ONLY public."BlockRequests"
    ADD CONSTRAINT "BlockRequests_pkey" PRIMARY KEY ("BlockRequestId");
 N   ALTER TABLE ONLY public."BlockRequests" DROP CONSTRAINT "BlockRequests_pkey";
       public            postgres    false    263            J           2606    17013    BusinessType BusinessType_pkey 
   CONSTRAINT     n   ALTER TABLE ONLY public."BusinessType"
    ADD CONSTRAINT "BusinessType_pkey" PRIMARY KEY ("BusinessTypeId");
 L   ALTER TABLE ONLY public."BusinessType" DROP CONSTRAINT "BusinessType_pkey";
       public            postgres    false    223            N           2606    17050    Business Business_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public."Business"
    ADD CONSTRAINT "Business_pkey" PRIMARY KEY ("BusinessId");
 D   ALTER TABLE ONLY public."Business" DROP CONSTRAINT "Business_pkey";
       public            postgres    false    227            v           2606    17456    CaseTag CaseTag_pkey 
   CONSTRAINT     _   ALTER TABLE ONLY public."CaseTag"
    ADD CONSTRAINT "CaseTag_pkey" PRIMARY KEY ("CaseTagId");
 B   ALTER TABLE ONLY public."CaseTag" DROP CONSTRAINT "CaseTag_pkey";
       public            postgres    false    265            X           2606    17212    Concierge Concierge_pkey 
   CONSTRAINT     e   ALTER TABLE ONLY public."Concierge"
    ADD CONSTRAINT "Concierge_pkey" PRIMARY KEY ("ConciergeId");
 F   ALTER TABLE ONLY public."Concierge" DROP CONSTRAINT "Concierge_pkey";
       public            postgres    false    237            �           2606    17684    EmailLog EmailLog_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public."EmailLog"
    ADD CONSTRAINT "EmailLog_pkey" PRIMARY KEY ("Id");
 D   ALTER TABLE ONLY public."EmailLog" DROP CONSTRAINT "EmailLog_pkey";
       public            postgres    false    283            �           2606    17660     EncounterForm EncounterForm_pkey 
   CONSTRAINT     q   ALTER TABLE ONLY public."EncounterForm"
    ADD CONSTRAINT "EncounterForm_pkey" PRIMARY KEY ("EncounterFormId");
 N   ALTER TABLE ONLY public."EncounterForm" DROP CONSTRAINT "EncounterForm_pkey";
       public            postgres    false    281            x           2606    17470 2   HealthProfessionalType HealthProfessionalType_pkey 
   CONSTRAINT     �   ALTER TABLE ONLY public."HealthProfessionalType"
    ADD CONSTRAINT "HealthProfessionalType_pkey" PRIMARY KEY ("HealthProfessionalId");
 `   ALTER TABLE ONLY public."HealthProfessionalType" DROP CONSTRAINT "HealthProfessionalType_pkey";
       public            postgres    false    267            z           2606    17479 ,   HealthProfessionals HealthProfessionals_pkey 
   CONSTRAINT     v   ALTER TABLE ONLY public."HealthProfessionals"
    ADD CONSTRAINT "HealthProfessionals_pkey" PRIMARY KEY ("VendorId");
 Z   ALTER TABLE ONLY public."HealthProfessionals" DROP CONSTRAINT "HealthProfessionals_pkey";
       public            postgres    false    269            d           2606    17317    Menu Menu_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public."Menu"
    ADD CONSTRAINT "Menu_pkey" PRIMARY KEY ("MenuId");
 <   ALTER TABLE ONLY public."Menu" DROP CONSTRAINT "Menu_pkey";
       public            postgres    false    249            |           2606    17493    OrderDetails OrderDetails_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public."OrderDetails"
    ADD CONSTRAINT "OrderDetails_pkey" PRIMARY KEY ("Id");
 L   ALTER TABLE ONLY public."OrderDetails" DROP CONSTRAINT "OrderDetails_pkey";
       public            postgres    false    271            �           2606    17756    PayRate PayRate_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."PayRate"
    ADD CONSTRAINT "PayRate_pkey" PRIMARY KEY ("ID");
 B   ALTER TABLE ONLY public."PayRate" DROP CONSTRAINT "PayRate_pkey";
       public            postgres    false    291            B           2606    16640 (   PhysicianLocation PhysicianLocation_pkey 
   CONSTRAINT     t   ALTER TABLE ONLY public."PhysicianLocation"
    ADD CONSTRAINT "PhysicianLocation_pkey" PRIMARY KEY ("LocationId");
 V   ALTER TABLE ONLY public."PhysicianLocation" DROP CONSTRAINT "PhysicianLocation_pkey";
       public            postgres    false    216            �           2606    17517 0   PhysicianNotification PhysicianNotification_pkey 
   CONSTRAINT     r   ALTER TABLE ONLY public."PhysicianNotification"
    ADD CONSTRAINT "PhysicianNotification_pkey" PRIMARY KEY (id);
 ^   ALTER TABLE ONLY public."PhysicianNotification" DROP CONSTRAINT "PhysicianNotification_pkey";
       public            postgres    false    275            ~           2606    17500 $   PhysicianRegion PhysicianRegion_pkey 
   CONSTRAINT     w   ALTER TABLE ONLY public."PhysicianRegion"
    ADD CONSTRAINT "PhysicianRegion_pkey" PRIMARY KEY ("PhysicianRegionId");
 R   ALTER TABLE ONLY public."PhysicianRegion" DROP CONSTRAINT "PhysicianRegion_pkey";
       public            postgres    false    273            F           2606    16958    Physician Physician_pkey 
   CONSTRAINT     e   ALTER TABLE ONLY public."Physician"
    ADD CONSTRAINT "Physician_pkey" PRIMARY KEY ("PhysicianId");
 F   ALTER TABLE ONLY public."Physician" DROP CONSTRAINT "Physician_pkey";
       public            postgres    false    219            �           2606    17821    Receipts Receipts_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public."Receipts"
    ADD CONSTRAINT "Receipts_pkey" PRIMARY KEY ("ID");
 D   ALTER TABLE ONLY public."Receipts" DROP CONSTRAINT "Receipts_pkey";
       public            postgres    false    293            L           2606    17041    Region Region_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public."Region"
    ADD CONSTRAINT "Region_pkey" PRIMARY KEY ("RegionId");
 @   ALTER TABLE ONLY public."Region" DROP CONSTRAINT "Region_pkey";
       public            postgres    false    225            P           2606    17072 $   RequestBusiness RequestBusiness_pkey 
   CONSTRAINT     w   ALTER TABLE ONLY public."RequestBusiness"
    ADD CONSTRAINT "RequestBusiness_pkey" PRIMARY KEY ("RequestBusinessId");
 R   ALTER TABLE ONLY public."RequestBusiness" DROP CONSTRAINT "RequestBusiness_pkey";
       public            postgres    false    229            R           2606    17091     RequestClient RequestClient_pkey 
   CONSTRAINT     q   ALTER TABLE ONLY public."RequestClient"
    ADD CONSTRAINT "RequestClient_pkey" PRIMARY KEY ("RequestClientId");
 N   ALTER TABLE ONLY public."RequestClient" DROP CONSTRAINT "RequestClient_pkey";
       public            postgres    false    231            V           2606    17183     RequestClosed RequestClosed_pkey 
   CONSTRAINT     q   ALTER TABLE ONLY public."RequestClosed"
    ADD CONSTRAINT "RequestClosed_pkey" PRIMARY KEY ("RequestClosedId");
 N   ALTER TABLE ONLY public."RequestClosed" DROP CONSTRAINT "RequestClosed_pkey";
       public            postgres    false    235            Z           2606    17224 &   RequestConcierge RequestConcierge_pkey 
   CONSTRAINT     j   ALTER TABLE ONLY public."RequestConcierge"
    ADD CONSTRAINT "RequestConcierge_pkey" PRIMARY KEY ("Id");
 T   ALTER TABLE ONLY public."RequestConcierge" DROP CONSTRAINT "RequestConcierge_pkey";
       public            postgres    false    239            \           2606    17243    RequestNotes RequestNotes_pkey 
   CONSTRAINT     n   ALTER TABLE ONLY public."RequestNotes"
    ADD CONSTRAINT "RequestNotes_pkey" PRIMARY KEY ("RequestNotesId");
 L   ALTER TABLE ONLY public."RequestNotes" DROP CONSTRAINT "RequestNotes_pkey";
       public            postgres    false    241            T           2606    17154 &   RequestStatusLog RequestStatusLog_pkey 
   CONSTRAINT     z   ALTER TABLE ONLY public."RequestStatusLog"
    ADD CONSTRAINT "RequestStatusLog_pkey" PRIMARY KEY ("RequestStatusLogId");
 T   ALTER TABLE ONLY public."RequestStatusLog" DROP CONSTRAINT "RequestStatusLog_pkey";
       public            postgres    false    233            `           2606    17289    RequestType RequestType_pkey 
   CONSTRAINT     k   ALTER TABLE ONLY public."RequestType"
    ADD CONSTRAINT "RequestType_pkey" PRIMARY KEY ("RequestTypeId");
 J   ALTER TABLE ONLY public."RequestType" DROP CONSTRAINT "RequestType_pkey";
       public            postgres    false    245            ^           2606    17267 $   RequestWiseFile RequestWiseFile_pkey 
   CONSTRAINT     w   ALTER TABLE ONLY public."RequestWiseFile"
    ADD CONSTRAINT "RequestWiseFile_pkey" PRIMARY KEY ("RequestWiseFileID");
 R   ALTER TABLE ONLY public."RequestWiseFile" DROP CONSTRAINT "RequestWiseFile_pkey";
       public            postgres    false    243            H           2606    16984    Request Request_pkey 
   CONSTRAINT     _   ALTER TABLE ONLY public."Request"
    ADD CONSTRAINT "Request_pkey" PRIMARY KEY ("RequestId");
 B   ALTER TABLE ONLY public."Request" DROP CONSTRAINT "Request_pkey";
       public            postgres    false    221            f           2606    17324    RoleMenu RoleMenu_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public."RoleMenu"
    ADD CONSTRAINT "RoleMenu_pkey" PRIMARY KEY ("RoleMenuId");
 D   ALTER TABLE ONLY public."RoleMenu" DROP CONSTRAINT "RoleMenu_pkey";
       public            postgres    false    251            b           2606    17297    Role Role_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public."Role"
    ADD CONSTRAINT "Role_pkey" PRIMARY KEY ("RoleId");
 <   ALTER TABLE ONLY public."Role" DROP CONSTRAINT "Role_pkey";
       public            postgres    false    247            l           2606    17375 (   ShiftDetailRegion ShiftDetailRegion_pkey 
   CONSTRAINT     }   ALTER TABLE ONLY public."ShiftDetailRegion"
    ADD CONSTRAINT "ShiftDetailRegion_pkey" PRIMARY KEY ("ShiftDetailRegionId");
 V   ALTER TABLE ONLY public."ShiftDetailRegion" DROP CONSTRAINT "ShiftDetailRegion_pkey";
       public            postgres    false    257            j           2606    17358    ShiftDetail ShiftDetail_pkey 
   CONSTRAINT     k   ALTER TABLE ONLY public."ShiftDetail"
    ADD CONSTRAINT "ShiftDetail_pkey" PRIMARY KEY ("ShiftDetailId");
 J   ALTER TABLE ONLY public."ShiftDetail" DROP CONSTRAINT "ShiftDetail_pkey";
       public            postgres    false    255            h           2606    17341    Shift Shift_pkey 
   CONSTRAINT     Y   ALTER TABLE ONLY public."Shift"
    ADD CONSTRAINT "Shift_pkey" PRIMARY KEY ("ShiftId");
 >   ALTER TABLE ONLY public."Shift" DROP CONSTRAINT "Shift_pkey";
       public            postgres    false    253            �           2606    17744 &   TimeSheetDetails TimeSheetDetails_pkey 
   CONSTRAINT     y   ALTER TABLE ONLY public."TimeSheetDetails"
    ADD CONSTRAINT "TimeSheetDetails_pkey" PRIMARY KEY ("TimeSheetDetailID");
 T   ALTER TABLE ONLY public."TimeSheetDetails" DROP CONSTRAINT "TimeSheetDetails_pkey";
       public            postgres    false    289            �           2606    17732    TimeSheet TimeSheet_pkey 
   CONSTRAINT     e   ALTER TABLE ONLY public."TimeSheet"
    ADD CONSTRAINT "TimeSheet_pkey" PRIMARY KEY ("TimeSheetID");
 F   ALTER TABLE ONLY public."TimeSheet" DROP CONSTRAINT "TimeSheet_pkey";
       public            postgres    false    287            �           2606    17600    User User_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_pkey" PRIMARY KEY ("UserId");
 <   ALTER TABLE ONLY public."User" DROP CONSTRAINT "User_pkey";
       public            postgres    false    279            �           2606    17693    smslog smslog_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public.smslog
    ADD CONSTRAINT smslog_pkey PRIMARY KEY (id);
 <   ALTER TABLE ONLY public.smslog DROP CONSTRAINT smslog_pkey;
       public            postgres    false    285            �           2606    17547    Admin Admin_AspNetUserId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Admin"
    ADD CONSTRAINT "Admin_AspNetUserId_fkey" FOREIGN KEY ("AspNetUserId") REFERENCES public."AspNetUsers"("Id");
 K   ALTER TABLE ONLY public."Admin" DROP CONSTRAINT "Admin_AspNetUserId_fkey";
       public          postgres    false    217    4932    277            �           2606    17552    Admin Admin_CreatedBy_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Admin"
    ADD CONSTRAINT "Admin_CreatedBy_fkey" FOREIGN KEY ("CreatedBy") REFERENCES public."AspNetUsers"("Id");
 H   ALTER TABLE ONLY public."Admin" DROP CONSTRAINT "Admin_CreatedBy_fkey";
       public          postgres    false    217    277    4932            �           2606    17557    Admin Admin_ModifiedBy_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Admin"
    ADD CONSTRAINT "Admin_ModifiedBy_fkey" FOREIGN KEY ("ModifiedBy") REFERENCES public."AspNetUsers"("Id");
 I   ALTER TABLE ONLY public."Admin" DROP CONSTRAINT "Admin_ModifiedBy_fkey";
       public          postgres    false    4932    217    277            �           2606    17419 +   AspNetUserRoles AspNetUserRoles_RoleId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "AspNetUserRoles_RoleId_fkey" FOREIGN KEY ("RoleId") REFERENCES public."AspNetRoles"("Id");
 Y   ALTER TABLE ONLY public."AspNetUserRoles" DROP CONSTRAINT "AspNetUserRoles_RoleId_fkey";
       public          postgres    false    258    259    4974            �           2606    17414 +   AspNetUserRoles AspNetUserRoles_UserId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "AspNetUserRoles_UserId_fkey" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id");
 Y   ALTER TABLE ONLY public."AspNetUserRoles" DROP CONSTRAINT "AspNetUserRoles_UserId_fkey";
       public          postgres    false    217    4932    259            �           2606    17056     Business Business_CreatedBy_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Business"
    ADD CONSTRAINT "Business_CreatedBy_fkey" FOREIGN KEY ("CreatedBy") REFERENCES public."AspNetUsers"("Id");
 N   ALTER TABLE ONLY public."Business" DROP CONSTRAINT "Business_CreatedBy_fkey";
       public          postgres    false    217    227    4932            �           2606    17061 !   Business Business_ModifiedBy_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Business"
    ADD CONSTRAINT "Business_ModifiedBy_fkey" FOREIGN KEY ("ModifiedBy") REFERENCES public."AspNetUsers"("Id");
 O   ALTER TABLE ONLY public."Business" DROP CONSTRAINT "Business_ModifiedBy_fkey";
       public          postgres    false    217    4932    227            �           2606    17051    Business Business_RegionId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Business"
    ADD CONSTRAINT "Business_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");
 M   ALTER TABLE ONLY public."Business" DROP CONSTRAINT "Business_RegionId_fkey";
       public          postgres    false    227    4940    225            �           2606    17213 !   Concierge Concierge_RegionId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Concierge"
    ADD CONSTRAINT "Concierge_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");
 O   ALTER TABLE ONLY public."Concierge" DROP CONSTRAINT "Concierge_RegionId_fkey";
       public          postgres    false    225    4940    237            �           2606    17666 (   EncounterForm EncounterForm_AdminId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."EncounterForm"
    ADD CONSTRAINT "EncounterForm_AdminId_fkey" FOREIGN KEY ("AdminId") REFERENCES public."Admin"("AdminId");
 V   ALTER TABLE ONLY public."EncounterForm" DROP CONSTRAINT "EncounterForm_AdminId_fkey";
       public          postgres    false    4994    277    281            �           2606    17671 ,   EncounterForm EncounterForm_PhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."EncounterForm"
    ADD CONSTRAINT "EncounterForm_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");
 Z   ALTER TABLE ONLY public."EncounterForm" DROP CONSTRAINT "EncounterForm_PhysicianId_fkey";
       public          postgres    false    4934    281    219            �           2606    17661 *   EncounterForm EncounterForm_RequestId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."EncounterForm"
    ADD CONSTRAINT "EncounterForm_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");
 X   ALTER TABLE ONLY public."EncounterForm" DROP CONSTRAINT "EncounterForm_RequestId_fkey";
       public          postgres    false    281    4936    221            �           2606    17436 #   AdminRegion FK_AdminRegion_RegionId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AdminRegion"
    ADD CONSTRAINT "FK_AdminRegion_RegionId" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");
 Q   ALTER TABLE ONLY public."AdminRegion" DROP CONSTRAINT "FK_AdminRegion_RegionId";
       public          postgres    false    261    225    4940            �           2606    17480 7   HealthProfessionals HealthProfessionals_Profession_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."HealthProfessionals"
    ADD CONSTRAINT "HealthProfessionals_Profession_fkey" FOREIGN KEY ("Profession") REFERENCES public."HealthProfessionalType"("HealthProfessionalId");
 e   ALTER TABLE ONLY public."HealthProfessionals" DROP CONSTRAINT "HealthProfessionals_Profession_fkey";
       public          postgres    false    267    269    4984            �           2606    17757     PayRate PayRate_PhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."PayRate"
    ADD CONSTRAINT "PayRate_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");
 N   ALTER TABLE ONLY public."PayRate" DROP CONSTRAINT "PayRate_PhysicianId_fkey";
       public          postgres    false    291    219    4934            �           2606    17518 <   PhysicianNotification PhysicianNotification_PhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."PhysicianNotification"
    ADD CONSTRAINT "PhysicianNotification_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");
 j   ALTER TABLE ONLY public."PhysicianNotification" DROP CONSTRAINT "PhysicianNotification_PhysicianId_fkey";
       public          postgres    false    219    275    4934            �           2606    17501 0   PhysicianRegion PhysicianRegion_PhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."PhysicianRegion"
    ADD CONSTRAINT "PhysicianRegion_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");
 ^   ALTER TABLE ONLY public."PhysicianRegion" DROP CONSTRAINT "PhysicianRegion_PhysicianId_fkey";
       public          postgres    false    219    273    4934            �           2606    17506 -   PhysicianRegion PhysicianRegion_RegionId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."PhysicianRegion"
    ADD CONSTRAINT "PhysicianRegion_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");
 [   ALTER TABLE ONLY public."PhysicianRegion" DROP CONSTRAINT "PhysicianRegion_RegionId_fkey";
       public          postgres    false    225    4940    273            �           2606    16959 %   Physician Physician_AspNetUserId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Physician"
    ADD CONSTRAINT "Physician_AspNetUserId_fkey" FOREIGN KEY ("AspNetUserId") REFERENCES public."AspNetUsers"("Id");
 S   ALTER TABLE ONLY public."Physician" DROP CONSTRAINT "Physician_AspNetUserId_fkey";
       public          postgres    false    217    219    4932            �           2606    16964 "   Physician Physician_CreatedBy_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Physician"
    ADD CONSTRAINT "Physician_CreatedBy_fkey" FOREIGN KEY ("CreatedBy") REFERENCES public."AspNetUsers"("Id");
 P   ALTER TABLE ONLY public."Physician" DROP CONSTRAINT "Physician_CreatedBy_fkey";
       public          postgres    false    219    217    4932            �           2606    16969 #   Physician Physician_ModifiedBy_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Physician"
    ADD CONSTRAINT "Physician_ModifiedBy_fkey" FOREIGN KEY ("ModifiedBy") REFERENCES public."AspNetUsers"("Id");
 Q   ALTER TABLE ONLY public."Physician" DROP CONSTRAINT "Physician_ModifiedBy_fkey";
       public          postgres    false    4932    219    217            �           2606    17827 "   Receipts Receipts_PhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Receipts"
    ADD CONSTRAINT "Receipts_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");
 P   ALTER TABLE ONLY public."Receipts" DROP CONSTRAINT "Receipts_PhysicianId_fkey";
       public          postgres    false    219    4934    293            �           2606    17822 "   Receipts Receipts_TimeSheetId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Receipts"
    ADD CONSTRAINT "Receipts_TimeSheetId_fkey" FOREIGN KEY ("TimeSheetId") REFERENCES public."TimeSheet"("TimeSheetID");
 P   ALTER TABLE ONLY public."Receipts" DROP CONSTRAINT "Receipts_TimeSheetId_fkey";
       public          postgres    false    287    293    5004            �           2606    17078 /   RequestBusiness RequestBusiness_BusinessId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestBusiness"
    ADD CONSTRAINT "RequestBusiness_BusinessId_fkey" FOREIGN KEY ("BusinessId") REFERENCES public."Business"("BusinessId");
 ]   ALTER TABLE ONLY public."RequestBusiness" DROP CONSTRAINT "RequestBusiness_BusinessId_fkey";
       public          postgres    false    227    229    4942            �           2606    17073 .   RequestBusiness RequestBusiness_RequestId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestBusiness"
    ADD CONSTRAINT "RequestBusiness_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");
 \   ALTER TABLE ONLY public."RequestBusiness" DROP CONSTRAINT "RequestBusiness_RequestId_fkey";
       public          postgres    false    4936    229    221            �           2606    17097 )   RequestClient RequestClient_RegionId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestClient"
    ADD CONSTRAINT "RequestClient_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");
 W   ALTER TABLE ONLY public."RequestClient" DROP CONSTRAINT "RequestClient_RegionId_fkey";
       public          postgres    false    231    4940    225            �           2606    17184 *   RequestClosed RequestClosed_RequestId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestClosed"
    ADD CONSTRAINT "RequestClosed_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");
 X   ALTER TABLE ONLY public."RequestClosed" DROP CONSTRAINT "RequestClosed_RequestId_fkey";
       public          postgres    false    235    221    4936            �           2606    17189 3   RequestClosed RequestClosed_RequestStatusLogId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestClosed"
    ADD CONSTRAINT "RequestClosed_RequestStatusLogId_fkey" FOREIGN KEY ("RequestStatusLogId") REFERENCES public."RequestStatusLog"("RequestStatusLogId");
 a   ALTER TABLE ONLY public."RequestClosed" DROP CONSTRAINT "RequestClosed_RequestStatusLogId_fkey";
       public          postgres    false    233    235    4948            �           2606    17230 2   RequestConcierge RequestConcierge_ConciergeId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestConcierge"
    ADD CONSTRAINT "RequestConcierge_ConciergeId_fkey" FOREIGN KEY ("ConciergeId") REFERENCES public."Concierge"("ConciergeId");
 `   ALTER TABLE ONLY public."RequestConcierge" DROP CONSTRAINT "RequestConcierge_ConciergeId_fkey";
       public          postgres    false    237    239    4952            �           2606    17225 0   RequestConcierge RequestConcierge_RequestId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestConcierge"
    ADD CONSTRAINT "RequestConcierge_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");
 ^   ALTER TABLE ONLY public."RequestConcierge" DROP CONSTRAINT "RequestConcierge_RequestId_fkey";
       public          postgres    false    221    239    4936            �           2606    17244 (   RequestNotes RequestNotes_RequestId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestNotes"
    ADD CONSTRAINT "RequestNotes_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");
 V   ALTER TABLE ONLY public."RequestNotes" DROP CONSTRAINT "RequestNotes_RequestId_fkey";
       public          postgres    false    4936    241    221            �           2606    17160 2   RequestStatusLog RequestStatusLog_PhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestStatusLog"
    ADD CONSTRAINT "RequestStatusLog_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");
 `   ALTER TABLE ONLY public."RequestStatusLog" DROP CONSTRAINT "RequestStatusLog_PhysicianId_fkey";
       public          postgres    false    233    4934    219            �           2606    17155 0   RequestStatusLog RequestStatusLog_RequestId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestStatusLog"
    ADD CONSTRAINT "RequestStatusLog_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");
 ^   ALTER TABLE ONLY public."RequestStatusLog" DROP CONSTRAINT "RequestStatusLog_RequestId_fkey";
       public          postgres    false    233    4936    221            �           2606    17170 9   RequestStatusLog RequestStatusLog_TransToPhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestStatusLog"
    ADD CONSTRAINT "RequestStatusLog_TransToPhysicianId_fkey" FOREIGN KEY ("TransToPhysicianId") REFERENCES public."Physician"("PhysicianId");
 g   ALTER TABLE ONLY public."RequestStatusLog" DROP CONSTRAINT "RequestStatusLog_TransToPhysicianId_fkey";
       public          postgres    false    4934    233    219            �           2606    17273 0   RequestWiseFile RequestWiseFile_PhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestWiseFile"
    ADD CONSTRAINT "RequestWiseFile_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");
 ^   ALTER TABLE ONLY public."RequestWiseFile" DROP CONSTRAINT "RequestWiseFile_PhysicianId_fkey";
       public          postgres    false    243    219    4934            �           2606    17268 .   RequestWiseFile RequestWiseFile_RequestId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestWiseFile"
    ADD CONSTRAINT "RequestWiseFile_RequestId_fkey" FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");
 \   ALTER TABLE ONLY public."RequestWiseFile" DROP CONSTRAINT "RequestWiseFile_RequestId_fkey";
       public          postgres    false    4936    243    221            �           2606    16990     Request Request_PhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Request"
    ADD CONSTRAINT "Request_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");
 N   ALTER TABLE ONLY public."Request" DROP CONSTRAINT "Request_PhysicianId_fkey";
       public          postgres    false    4934    219    221            �           2606    17330    RoleMenu RoleMenu_MenuId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RoleMenu"
    ADD CONSTRAINT "RoleMenu_MenuId_fkey" FOREIGN KEY ("MenuId") REFERENCES public."Menu"("MenuId");
 K   ALTER TABLE ONLY public."RoleMenu" DROP CONSTRAINT "RoleMenu_MenuId_fkey";
       public          postgres    false    249    251    4964            �           2606    17325    RoleMenu RoleMenu_RoleId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RoleMenu"
    ADD CONSTRAINT "RoleMenu_RoleId_fkey" FOREIGN KEY ("RoleId") REFERENCES public."Role"("RoleId");
 K   ALTER TABLE ONLY public."RoleMenu" DROP CONSTRAINT "RoleMenu_RoleId_fkey";
       public          postgres    false    247    4962    251            �           2606    17381 1   ShiftDetailRegion ShiftDetailRegion_RegionId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."ShiftDetailRegion"
    ADD CONSTRAINT "ShiftDetailRegion_RegionId_fkey" FOREIGN KEY ("RegionId") REFERENCES public."Region"("RegionId");
 _   ALTER TABLE ONLY public."ShiftDetailRegion" DROP CONSTRAINT "ShiftDetailRegion_RegionId_fkey";
       public          postgres    false    225    257    4940            �           2606    17376 6   ShiftDetailRegion ShiftDetailRegion_ShiftDetailId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."ShiftDetailRegion"
    ADD CONSTRAINT "ShiftDetailRegion_ShiftDetailId_fkey" FOREIGN KEY ("ShiftDetailId") REFERENCES public."ShiftDetail"("ShiftDetailId");
 d   ALTER TABLE ONLY public."ShiftDetailRegion" DROP CONSTRAINT "ShiftDetailRegion_ShiftDetailId_fkey";
       public          postgres    false    4970    257    255            �           2606    17364 '   ShiftDetail ShiftDetail_ModifiedBy_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."ShiftDetail"
    ADD CONSTRAINT "ShiftDetail_ModifiedBy_fkey" FOREIGN KEY ("ModifiedBy") REFERENCES public."AspNetUsers"("Id");
 U   ALTER TABLE ONLY public."ShiftDetail" DROP CONSTRAINT "ShiftDetail_ModifiedBy_fkey";
       public          postgres    false    217    255    4932            �           2606    17359 $   ShiftDetail ShiftDetail_ShiftId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."ShiftDetail"
    ADD CONSTRAINT "ShiftDetail_ShiftId_fkey" FOREIGN KEY ("ShiftId") REFERENCES public."Shift"("ShiftId");
 R   ALTER TABLE ONLY public."ShiftDetail" DROP CONSTRAINT "ShiftDetail_ShiftId_fkey";
       public          postgres    false    253    255    4968            �           2606    17347    Shift Shift_CreatedBy_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Shift"
    ADD CONSTRAINT "Shift_CreatedBy_fkey" FOREIGN KEY ("CreatedBy") REFERENCES public."AspNetUsers"("Id");
 H   ALTER TABLE ONLY public."Shift" DROP CONSTRAINT "Shift_CreatedBy_fkey";
       public          postgres    false    217    253    4932            �           2606    17342    Shift Shift_PhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Shift"
    ADD CONSTRAINT "Shift_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");
 J   ALTER TABLE ONLY public."Shift" DROP CONSTRAINT "Shift_PhysicianId_fkey";
       public          postgres    false    253    4934    219            �           2606    17745 2   TimeSheetDetails TimeSheetDetails_TimeSheetId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."TimeSheetDetails"
    ADD CONSTRAINT "TimeSheetDetails_TimeSheetId_fkey" FOREIGN KEY ("TimeSheetId") REFERENCES public."TimeSheet"("TimeSheetID");
 `   ALTER TABLE ONLY public."TimeSheetDetails" DROP CONSTRAINT "TimeSheetDetails_TimeSheetId_fkey";
       public          postgres    false    287    289    5004            �           2606    17733 $   TimeSheet TimeSheet_PhysicianId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."TimeSheet"
    ADD CONSTRAINT "TimeSheet_PhysicianId_fkey" FOREIGN KEY ("PhysicianId") REFERENCES public."Physician"("PhysicianId");
 R   ALTER TABLE ONLY public."TimeSheet" DROP CONSTRAINT "TimeSheet_PhysicianId_fkey";
       public          postgres    false    4934    287    219            �           2606    17601    User User_AspNetUserId_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_AspNetUserId_fkey" FOREIGN KEY ("AspNetUserId") REFERENCES public."AspNetUsers"("Id");
 I   ALTER TABLE ONLY public."User" DROP CONSTRAINT "User_AspNetUserId_fkey";
       public          postgres    false    279    4932    217            �           2606    17567 "   AdminRegion fk_adminregion_adminid    FK CONSTRAINT     �   ALTER TABLE ONLY public."AdminRegion"
    ADD CONSTRAINT fk_adminregion_adminid FOREIGN KEY ("AdminId") REFERENCES public."Admin"("AdminId");
 N   ALTER TABLE ONLY public."AdminRegion" DROP CONSTRAINT fk_adminregion_adminid;
       public          postgres    false    277    261    4994            �           2606    17616    Request request_userid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."Request"
    ADD CONSTRAINT request_userid_fkey FOREIGN KEY ("UserId") REFERENCES public."User"("UserId");
 G   ALTER TABLE ONLY public."Request" DROP CONSTRAINT request_userid_fkey;
       public          postgres    false    279    4996    221            �           2606    17626 *   RequestClient requestclient_requestid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestClient"
    ADD CONSTRAINT requestclient_requestid_fkey FOREIGN KEY ("RequestId") REFERENCES public."Request"("RequestId");
 V   ALTER TABLE ONLY public."RequestClient" DROP CONSTRAINT requestclient_requestid_fkey;
       public          postgres    false    4936    231    221            �           2606    17577 .   RequestStatusLog requeststatuslog_adminid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestStatusLog"
    ADD CONSTRAINT requeststatuslog_adminid_fkey FOREIGN KEY ("AdminId") REFERENCES public."Admin"("AdminId");
 Z   ALTER TABLE ONLY public."RequestStatusLog" DROP CONSTRAINT requeststatuslog_adminid_fkey;
       public          postgres    false    277    4994    233            �           2606    17582 ,   RequestWiseFile requestwisefile_adminid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public."RequestWiseFile"
    ADD CONSTRAINT requestwisefile_adminid_fkey FOREIGN KEY ("AdminId") REFERENCES public."Admin"("AdminId");
 X   ALTER TABLE ONLY public."RequestWiseFile" DROP CONSTRAINT requestwisefile_adminid_fkey;
       public          postgres    false    4994    277    243            �   %  x���MN1�מS�e;N�̪\�t��F�E� $nO�RhY�r���}����ZQ�wV1e��4e%9��Di�Xˑ�Q��n��"K����T�/� /o`�yغ?n�������dg��5e�#oi��&Vڴp=�e�f��)x�?���j�x��b]����B�:g2�r����!./W(-��6M�P��x,��1�����`4�%������2��h���ݷ�qKf8��W���[���%X���k!X�p�������FiR��`I��P�n?t]�	`f��      �   1   x�ɹ  ���T�}�^���Y�b�2�-�J�mM��AD'y��l      �   t   x��K� E�q؋+l�s�K'&)�~��]���хf�r4F��3�&) h����q>Sǘ9��*Ʊ�T~D��`�~ƕ�d�����PYڽ7r�������������R�O"�      �   �   x�����1��\x�����P�!�BXc���yN��5���"d�kc�`t����
`��D�n�[�`�v�(���A�(j�X��`�=e}o�pj�}I�й����foa�w��u�+V��,sa��ѩh�n�� �r�@d�Z<����n����دxL�M�t�w}����~�1��
Hܾ�X��)4�ۇ�[���rC5)fC�FJ����^�àF0�r�y?���H��}�=�D      Y   �  x��T�nG<�|�~��&��n�i�@w_؏Ymd9�d��߇��c9Z��=@����BJ=
����$@��1������ͣMOOO�}x�>��_�!`�¼2�T��F���fqh�L�`F��5�A=�Nǣ_�����N����ݿ��
qeY�.%b�<S�)F(�`��(c5�Vs���}}}�� �(+�%x�<���2l�⺉c�Bl�#�!�4)�~Y���)P~_��'�����KQ�Y[��%B����px{�D2��vba�N��P�����J^b̙��B����T����խ
�,2��m/��}��7���H��ECL��"�,��
�A��Q��#���q":#^��RXr��p�6wA3Ľ˽1�Q�%��e�ԏ���S.:}}����;���
e�3��!�\���V�V� '	`�6H#Q���N�����s'd���p~����v��s����Z�ع��45��}�;Gm��'~���@��\9t�6)5ef&��sջ�H������{B1i	�;Ey���F\DB�yT�n�X�~�g@A5�Q��|F���j��"��/�rL+����y5�>��k ���]!�,V��YӇ���>��X�t^�a_Ƨ�$CZ�W�%+Ls�ac�J���@���H�5+m�Ý�Í۩�O���pc7��;Ly�!	O��{���ӳ�R�pgz�zo��&S��7_�]9�rB)�t+����4q+�`��!�8ĭ��d���B�<:�h႔i&����z�>�@6ȑ8�5��6�	�YN/���#�D��VC�ӹK�`���F�|ح�to��t�J������(�nݴ���27�鈆І?���Ġc�B�m�d�nO�o��c�������y{�ʢ�)��q���o���$      �     x���=n�0�g��@�I�5�S��g���mb'Ha��/�t��$���H@��4u�ס���y.Η�h��sl�� \��Yw(;��(���ʐ4X��:��O&c�;B��1�
�tvbւv��]_�{y~���%f>DUJ+���S�m���d?��e2��	��i�cAh�s2�5�����R/�G��+�k�x����f�d)��[�a�����.4�~5�">V�e\�� t�?ݱ�i���V·}��s�ыhg      c   �   x�u�=�0�9=Ev�ȿq�p�B����O�I��,y�g�p<���I�D,N�`	��UW�q�%Ѽ7��U��.5�a<OcS-��_N\!�)�֜��1ϧ͂���"���I� �f��vi��2|�&n�r1;��&E��)ja�\��Ӳ��Nᣮvi�JOќ���)5}L]׽/uk�      _      x������ � �      �      x������ � �      m   �   x�]��n� D��W�F,�L�.R�S�t����	��u����4��o4�<�)�[�-�aMk�2�-�K�5h�iTӨH��h���Z�-\/M�+#�[�-�w�Y!%hI��Y癥����a�� ��!��Ϯ�4��^)���Yk�6�lK]��r�ܟ��Q#�x�"�q��h���^��fc�Q_ţV�S��ʒ���U��ІG0      �   $  x���ێ9��=Oa�~L�϶��G����F���8`�;���v��מa2�$�`t��������2�>ҷ�6]��{����O&��4,�M?x)��>m\�]C�]�y������$�'���t�yXd���}S-�t�"���O�=8py�E��S*ƅ����d H��_���ǡ�iN[�«D&�㮤av��Z��j�R�<���aIBaw��l������!�����������]/H�<��Uh����+l���(�(Kr�m�}�ٶ���U��PG��o�v������e$۶o��ua�Vq�6���p�H�]X�ˑi�K
*�?����C$5�zV��ɑ�'���2�Z���pN�z�~10��[,IB�F�`d�c��lQ�12�?R��i���~~�w�U��~^7��f=���ʴ�?�zi�t�"$'�������l[m�?�4��R���3Ԇ,K|D�W��0k�E�~`
��Z����3��U�ԞZ��Q~��6�}Ww1�� �|���H]�U}"��C�6��A�$��/\�ԕ͗�%�RR�^/$��	tEɸ�\�ġ�B_���I␧�Hǭ,I��Ol)u�ߧ� ��4"5��I��(��]�2��(�S9�����d�|������+`Ji88S�$9���N˓asR�8��~�����W.-BBZ,K��sq��:�78�/Kc��������g���<Z�V%��Q��bm����qq���iw^I�5��E���H_�m�_Ӎ��s�N� y��7Z��4si�8;��8��!_gWy�ϑ�ڀQ����nnn�w���      �   X   x�3�4��L�L)����H�H�L"QzZ'H��H�P�.#N#S�BC+�A?�˘��!_�B�y�`/�H����=... g7;D      �   6   x�3��MM�L��K�4202�50�5�T04�26�20�3575���"�=... �
m      �   �   x�U��n� ���)x�C����H��&�5Ķ�9�押}�O,��b����qJ}?&���Kw@@j�e烆����^�,�}�t�6�iJ�X��?�	�dN�N�R�h]��l�\������5�?U���#^�w9P���%��4E"t��S�\R$����hè�M�&"�����H&ZV�z��Y���0�+�w��!�D����r��]�����~qk�XWW�̐�E	!~�[L      y   :  x�]�Oo!�ϳ�YX���h��q���*���o_X]{�73�y�l�A�q@`�VP��Q��V�H�[fhCz�4WT�i����[���s��5�Aacq��@#�1w�FfEc�b[$%���f@����y��OiZ�4{̬j�ҹ`'�ԡ��>��0?3�Wx�ۑ,�Ɖ8+Ӹ`>���0�>���L��Rk)�h�g2�o�B��}ZF���G�Mf��D����ь�����|~7AF���h����F~��=�w2Id ��~ؤ���cjt��%�q�\�TeZ)=�M��fE;$�TOaE�{)����O      �   v   x���1�0���9H�;�3�=KD
T*B��o��!D�YRVC8��������c�<�0n+�=8�߇��c�1w��RR%����*�S�Ѧ�eO֡��L��/wι/V/*T      �   *   x�3�4�47�45�43�46�43LM�9�@$����� �2c      [   �  x���M��0�s�O�D21o㩥B{Zz�e��Z�<���~�����ҥ-� ��2��̶�0"Gj��"�:*N�v��n� V���0�76�n%�����H���4�w ��u(��cU��5-��9�4M1�}���LÐ����nsJ���!Q�x�=.}�i��e���}ڏz��(�T\H&Qj,5� �|�s������pg>�L���R0R��R���d"^(�V�SuK6�2#M4�+�q`G>�+t�hUH�8G�8�76��)A�
s���������1���:P���	Ƚ��)D�d��re�񺁖G��([k�Tu4[:�X��=��
������<G�k����~�|h�9.K��$Y��G&��z��}�� ��,� �?�˪8�4d7��ͱ�@�_.��:��      X   �   x���1�0 ��yE>��vbw�
k�"
��4|��MG��9��!���4�!F.�@	'�I(�+�������k��[�Pz��P/=�$��7�����`R��%99^��߾�Ϟ,)��1�-_      �      x�3�4�4�2�4�4�2�4�c���� !��      �   /   x���  �w����b��Ji��M����V+9v�6x���]      �   �   x��ѱj�0����zI�C�V�K��B�[�|v�*+��}��KW��M����+u��@�j��֕n+m���e���1�D�C �=ėė�#>�Ǒw��yN��t�#��	�D�|�e{�1J�y��3M�q4�������:�z��>n4e���ﳊavQ��x���v�-%��r�)c�ޏ�� �B��CY�)������!��_��X      a   M   x�3�NLJ,�N�+�H���8��R22���@l.cNǌ����0�˄ӫ$��fp�r�%��H�=... ���      ]   �  x��X�r�F=��B��Q�/8!�T|�'9�B�Bm7�����!� �r�^���ݯ!=�Lh6�� ���ŋ�=��zK.�'.?�p+TnB�B&���3�~���o�od DǶ-[����bu]5�L��\����8����x��$����/��Z���Q�[!r�rɳd��㘚3E�=`�Å�m6~d��"�["r�L��I��jYt�e�ꪬ	[�k�ž�E]� ���s-3�E��2|��IX"�_�Sܰ��˱�d�~Ӳv��L�M�\ԋIZB�]���NҲ^���L�U���m1�w�T�[�s�sn2㕔Ӑ�0)�B��fQ7���)�@v��~�'V�+�J�7�a�j}Վ
!��75[4���T�����#�� �S�S���:>-�q��$���բ��ǅ�XU7UщО���7�ν�������Mg�4�=�ߴ�}K���x���f$tnx�y��

B�W�-�͡8�s�X�g�����N��ԫ�����B�}��Xլ�K�@�MųZ�2�{Ƚ�ř�%pn����]����5h9���:?���uJ���<z����h%W�]�i�`���|�>��f���W�2j���;��BM&���B�u���~� �����:-����e������x�E�\=�����y�y�??�T'`�����G�DI�����>z^�:޷�����r��&�{�ww���o�>$�AN"��F`�
i�CS0�4��I`�����˵ΥϬᘛWap8�ސ�:�D�I�@|�-U%��=�Es+dn��ڵ0g�6�0R(d�0�^^�~�ί��+z�l�C�EJ�T�J���|dԢ�2+}g�5K���u����=gGd�yR�JT2τ�T�O�� Y�U4�����k���V&.�N��~�U%埖L���%e���t�!sU�#�P&d�"'^�S̎���XdɩE��u��9�1*l.!�ꕝ��@C�YzT5Y�T2h�����~�2�F&%������e��a��4�b��X���!р�	��aڦ�dm�#��V�^��$�_�dݕȜ�^L��r6��a3�갪�UI����p�rU�U���<����h5�A��f�r6f]"�y��`Uk�vܬʸhꕰ7R_Q�&������ �%2��r_|>ߘ:��-It�^N��D���K�E��/��8������8���p��� $T���>a�1����1��T��PG���P�(�k�sc�z�IJf�إ7MQ���"���_e�{>5�.b'�\��J���V� ь�rq�S �OC�S�U�2ދ1��~l=���#���kc�6���-�i/-}Q�k���R}s����؉l,��]�����䋕D���x�8j�'���l���Gղ��4��l��ˊU]�������|0kΫWEѡz���t�Gj�ƚ��'���4W���6þ4��Ț��I����8���p�*�	���Ԧ'�_��l	;ml'0O���a��|
����_�����n*ru5�0�~��-�+��BxC`0+#8 �׬�<���YC>ʓ�1TN7�W�9�op����f��mSt�1� tfe�A����y݌<,����<����gW�Fkz��촫O4mG��pZ�
T�K�L`���<
�[vss�V\�      e   7   x�Ʊ !�x]��|_�ׁn�ٔ��?��=���A�P2�0ǻ+"X�
k      g   ;  x��Xێ�H}��
�G�@sy#�jWJ��f���|Ʉ�N���{�2Y��x<���ԩ��\rҚO�z�����R��&��V���ˑ~ϟ�s�t$�8&!�Ș��c�<Þ�$7��Ț9��c��N4�KO�uDD_�O�����q���i�c�J��K���=�1�!�CEQ�_��I��څ�u��ߒ�#� �9���"�}Z�I�Ր�0��Oi��=��i�gs�G�|w>�X���^�v�m����k�Ԯ�cH���Jwn��B�Ǐ�G��6Y�x�f��|���a��qxn�gݝ�뺤���,+{�,���6U}r#�p��3F8�A������o�:U`�
8�ndn�˷7ſ�fH� �h��8
�{�p(���*Jk���Q!����8�C��\�Q�����Cz��A6mמ�ʚ%�-%?��m~|�v�2��vT�5�����+�E2r���e�4]h�-�7e)~�2�'?"z+�a��i�@�[2y�����䍱�4�j�<"
\:�������e_j0I�wTN�K"-�U��S�QC���p"��M���`o����#�u^��=���]j\��l��>)����PƑ��pQ���D݅|QCA��	G��)����d��B�/bK=�Q�$ �,Kf�|0D���
�r�|�ލ����b�"�E5-ֽ��2$)��eMx�z�̠Ш Q缴B�Dω"�٥�mM�*?"�r�����9�K��f}�%Q��߈D��|�9e�P��`�:=O�^�(�Ω�1,����;�>>�I��Ui��.!h;��	ZIW�bwɲ�e�j�g_��h�
� ́\ۇ ��jX��΃�diJ��{�%կ�Xz�~�Z&��q��#��.Vtmѕ�mГ;hmY�v���U��X��/��n��'0����aXD�.�h�y�_�!�~�a�1(�����-��A�_*N��_����Q�<�W-J����+�����������]��#h�� �5�B��i�P�����7��s	�0�,�<i,�
M.���k |�0�Y x1�Xf��	ݣ���i'@BS��_��p�" ����>�v�ٙ�x�R|4�>�}�z�W҇�8�\bz��<�M	���*g�~��r�Y�����ɩ�P�7D�fb��m�y���6k���v�_�.�]�C��[�=�SE�j?�G~"���*^���ʴ>oJ�
�-X���~Ag��4��r/���;[iZsGɍ冝��MlI~Q�nn�;�Z&��e�B1
Kxźb{��I��AY3(�p ύ���a�̾�u�������&�3�&�G+^�?Qg켱���e�� c����f�wÃ�m��v8�-��T��>�O<��P&x�u,�Ɏ�Mo������ �FP��t?�	��Se�F�S���e���}h�K���p��*T�i�6������������!�E{u������F:B����y�Ul�M�=�T�!*g0=4Ög�)z��9yc7W��M\A��-Ɨ�cnf{�奋	z����Pz�&=�_�����KL��3���S�feN{��o1�|`�b�^v�5�Ϗ� �,�      k   X   x�Mλ�0��<L`I�?Kd��?G��V���H<���P��(>�,H|�U0��v�$���H+��$��:��8�p�G�s��^�$�      o      x������ � �      q   :  x���Kn�0D��)t$%�w�� 7�'��m�.r��MјF[� ����8� ��ǻ�o��|5�K�]��y���p:��>ٷ�Z"CT$t։$vkJ��'��i�"Đ+�X|�
!H!�q�SA�=y��A��a��)?m E/
 ��O:�R2T-`5b9cf廉���h��\VM^i�e�N���?v�bc�bC"
YA28�Ew���"��M�)�(��6ïB�R�5��3k
��(�����Bɦ�9�l��钌�8Mʙ��Kѐ������@�u?7�k?���"�]���1G��٦i> <�      i   �  x����RI���S�����	�1�9���$��A&췟̖��[������ϥ���p����o�mϋ����ݪ! 9:��b�z�.eR��??���8I�҅H��ǹ��<��=J/�	e�=q&��G�CN{Z�wӱg� ���&�L���� R�Ӡ�uņy
]_��)�)uj2�,���������bP���s�А��ы�����j�nڧ�����~u�]̾c�F�ETf*z!4��1����b�~_lWw38� �k�ņb�������~�ٶǂ�s@����萓P����ٯ2Ңv|�RD�bR4��&��Aڃ�;vY$�W6s�D�O�A�g�2t�1��^4O�L���!$=`'5#��-Oc����C�HL�V�CZ�8i=2��n�u
�X�K����#�@������z�1�-��4Gl!�:TG��B(��7)�]�\�"l'A��!22Jќh�,��#T��<R܈L�|��Щj���� /	J�5ݙ� �_�I� ��Z_�$U;3�N"��>dr/�EF5����D��H�S$B��]DtDn���:V��9�^^���N��՜j�IV�w~�Y�ln,����˿�|��h��I)����������&�*E��a/��O���͚b�)���N1޺������E���/&DN�j��Ҙ���_3D}�Z˔4�c�C���f���$\O2�$�6�Fhh:�^k����d�O3�v��0(��F���c}@�$��Տ�f����P��&zQ�覸Nո��!�W�a�@�;5:�R�׷�C�|Fb����:[%�_@l*v!q] ����qه��gQ�� ��d)x�~�5ӄP�蜂(;��ru�g7��|<	������h�[��I�{�)����M���|���l����,[��Z	�kPn!نٳwD1���O'���)	$,�ێɯƔ�ۃ��T�B����J�@C+�p��g��˫eŮ�M�zTh�t�]��	F�4"�Է����q+���PIRlnua±)���$�B@��@�)Q��t9Gݗ��dH,�5���8�[���zڶ���r�}k+���������r�x�9Oa� NuAGo�0�����]��@���!x�a �P��5�O�9o7�ImpY�4��.y�$��d����f
�����������l��=&���O��ƐYj���M����%���J5y魃lA�E�$Tq�G��r{�1轋�3o���G��5}ƍF%�4�KH�=�	���F�$��Nm3��R�}5c�w�F&�FeUiy�h��w�ɾw};��;�u�!�Vc{�����v鐾j���IC��Ǳ��R8XG/�.35н:�#6������X��w���Òo%|��;H��eR.��ó�X[�s�a�U�GI�KИ�?���s���a%���J�;��� �|�c-�c9%j��r�Ǥ�͇A��?��bo���\t�ڝ����V�h      u      x������ � �      s   �  x���Ko�V�����2^�vf����n7u��@�J��@&����!m�M��`�\�~��9��gd�O�(��}l�u]U���UQ�����O��(^^^��n�����W�cQ|^7eY�u��ku�327@7�r�ɘDA�:+�G>�?�f��q���#��!�1$�x]$�����K�e�9b26P�k+���Q���@'��
! I@��~zX���j9�Z�IS�FaD�b)B��b 0Fb}"T<5�D�$��I�V*	Af.����i��~�a�>G��%DE�z���pA����-��O%��K���� GH�uj4a(s8�T<;2	�2��$���,��hIB0K h�+�.�`�(�M��{�n�*�	㔎�Fi5CFv6����<�S�j�	��>R�+	�$�`��FM������i��[�aS���cQ\�6���/��-%$坷N2Q�]3��=��<��|�:n��W�&�_����}},�c�jK��0����@Ec�@4Z�oƟowǶn�����=i'v,.@�V��+_�?_�ݼ�o�j�ޔ#�Y�Ӳ�����f:7�ҏ�W�M5�����7`%!��)�]>&��ٔ�q�X�����ˡy�~��v���x�?����y��ǰt����$Z�5��)�1}�N�mw�#�+Z�H#�~�C���u��㶌D^yE�s������0GC�@��`��[J�|�E�v5��ҤB .�D`� �c5 �D�X2��m�~�Y���vkQ�"������{�#���y������-@�a� ��8��=�cx�>���ZŶ;ysF��g4��_���	e�fY4��O�u�5�#����S�Z|)��M0�����WG��&MbH�����@{�FKR̸L��[B�%���\�ҩ(~���sՖ��wu��wxf�|��B�
�u��ّ��O��h�]5��>�����"�U�R�	3�+P����?]y      w   �   x�m�=
�P�z�)�������].r I@-"�T�}|�Q	S��z�&���\VH衽���$�O@M��k�r�n��ܗq=���F�1�RQ�@��i&>ߥ��![��R"L�K[�m��4�f��S-{�L���޴����=�s���=�      {   �   x��� ߤ���뿎#�aGĝ`Eѱ#q�n��鼩נ@��������I���/H�
n�d	�y �x!�� �� �D�>	�O	�#m�}*�}j�3����5	g��V蠮9��|�婅�)��D�����%���A�'�      }     x���ˍ�0еSE��?)�*���$���di>
0�xxc�9 �H:��B@��]����o�7�oȞ0��}Mk�����m��Cn?��+j��٢p)���"��;�G`����M���%����״ŦIL!��ۖ�a�Z�T�uWK+:"�^q��wd�ʑ���\^�����Kf*������+��W�*XQ�c�N�t��-�CH�:MS ���=�V�#ee��.�i�V��(jC�9?�w��U���:wX'��p����9�
��m���ʧ���2;�uا���1<���b#O�%����0�/�t�)���\2��0��;&KE�A�:j����|��ѻy�)s	�>(���Z�2E{�7�i�Ui9��b��9!8���lk���sn}vJͱ��v�V��!�Y2�~��fe�����ty�ϥ�șO:���m�e��Ի��,Y��F���yӑ���P*�.:Ȑ_V��yȭ��ud6r~YuzTn{p�v˗<�ߠc9�K��(�E�v����V�         �  x���Mn� ���S����=A֕�ɪ�޾�r�!�V�%z���8��0���+mo���(�K����s�(�ED � �cI/ �3�M8 �(�� ��
�M(�3�^� hX0 ��ۆ9���Iۓ	��z�C~�'�WDIW�Qn �.w+�Y�����h��I��c@"�]� �V�S1ހ�a�)A�&��qs��9�F�B�}@r�Y�Y�
�����^	�u���!�]C�(u * ��02,(����O3_��	Z���)j8f������%�R��y�� qJ��4���d��e'��h�[]�wꠈ�U�A-@(�"Z�4L��H'��&��<5�!��O�.c�[O~fwIm�����;���f����,?�J      �   <   x���	 1þ�a��M_�t�9.��;�Fh0���4'�~��Ͷ?�˭G����>I?x�	�      �   �   x�m�9�@�:s��������qN�j"q~���Ȯ��ϝN�`H�j�����|���H��.����:قՓ��sN��Nb:u+6O��e��q�_���ȁ뚝��~{\/�8���jx�6ueD�B�B��}ѱcNp}t�=ӣ?�      �   O  x�m�AR�0Dѵ}
.J3��%�p��(N�
]Pl�������VΟ��׋�[�[��R>��^�E�V� �IqM�j� �IIM��I94 ]+ C�]�P7t]C��uum���.�O���>I�71
=��W���+�|���y
$�X�8_Vn��.��/#�=^6�O��},lE.l�	��k��V5AWM�p�e�n�b���D��?��0���5�q�&ڋ&X�ML��	���	����c{jP�0��:/�v��kG����7}#���Ҡo�&�M�C�.��oM�7�&ț�	�k�o��	ꦮ먛���n꺎������ ]�<�      �   �  x��Uɒ�6=����)� �࢓O��N%�N�s�HJv/N�KO�������ꈤMɦ� << �����N�V�0Z�;�M�T�S����9�mzZ���<*$c٩/���~[�^����@5��C�Y�R��!m�� @Ƀ?�~]7{�'��4���ڞB�b=b;�z� �4��LM:���%�:%��%�Z���4�y�������?�Ĺ�̷�0ƨ�Ë��ro�	�9xF� X�\��FF�N�qH)���ww�;1No���oi�W�H�,���w�hc��b�h��Rչx#P(�0ko��l�U�qNa;�O㴹M�K��*3�s�M��1s ��8�2��!�A�̬I#UF��T�D���4-��h~�V�:������tT�ǽ�=Pǀ>�:C��8L�s�m҇�IF(4����u�M�f�>�����m��Y��Z�>Dg��u{xl�
�L��ų�	h�L�#�3^���1����t����M���A�z����5Ȼ݉w�K����ً��1�b϶g߉�d�@N���u����Dq8����a�gV_���*k)����=;�����M�c?���J��l��HI:0�`S�.U4\j����s�܇����	6�=A"�Y)���������ґ*�I
H�9G_-�*Ƣ,��y)�avA䧽���yMW��=lj�ju��y���4�J��T��V�lD���E�8j�9f4*�n�}����)���� ��>�W�mY���B}N��ZoҔ����^^��x���ꌈ��m+�d�Q���\	����k�:,�r�:EϺ/�X��%�?��xH�UZ�G��2��]d)�V(U���U��ZA}�����,���{�0y��LJ/̉5b�I�V5D=$�Z�\��@�0N+ux����u"Nı�f'��ʨ�e{��k��!�Q�7���&���;�/������*      �   d   x�}̻	�@E�x�
sq��3[�lF�?�`����]8�~��D,j�F"��>�!낺�LDM�Y�d���fp8=cuSaz��&�����Iz뽖R.[_%     