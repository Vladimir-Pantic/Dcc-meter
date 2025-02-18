

--Represents audit of the users' interactions with the system, as well as record of automated system actions.
if not exists (select * from sys.tables where name = 'AuditLog'  and SCHEMA_NAME(schema_id) = 'dbo')
create table dbo.AuditLog
(
	--These are standard Serilog columns.

	--Unique identifer of the audit log entry.
	Id bigint not null identity (1,1),
	--Represents readable message that has been logged.
	Message nvarchar(max) not null,
	/*Specifies severity of the entry:
	0	Verbose: Verbose is the noisiest level, rarely (if ever) enabled for a production app.
	1	Debug: Debug is used for internal system events that are not necessarily observable from the outside, but useful when determining how something happened.
	2	Information: Information events describe things happening in the system that correspond to its responsibilities and functions. Generally these are the observable actions the system can perform.	
	3	Warning: When service is degraded, endangered, or may be behaving outside of its expected parameters, Warning level events are used.
	4	Error: When functionality is unavailable or expectations broken, an Error event is used.
	5	Fatal: The most critical level, Fatal events demand immediate attention.
	*/
	Level int null,
	/*Identifies date and time when audit log entry has been recored.*/
	TimeStamp datetime not null,
	/*Contains details exception content in case when error occurs*/
	Exception nvarchar(max) null,
	/*Additional information (custom list of key-value properties) logged in form of XML.*/
	Properties xml null,

	--Non standard Serilog columns

	--Unique identifier of the application which has been source of the log entry.
	ApplicationId int null,
	--Name of the application which has been source of the log entry.
	ApplicationName varchar(100) null,
	--Version of the application  which has been source of the log entry.
	ApplicationVersion varchar(36) null,
	--Unique identifier of the action (method, operation) which is source of the log entry.
	ActionId bigint null,
	--Name of the action (method, operation) which is source of the log entry.
	ActionName varchar(200) null,
	--Identifier of the user who initiated action which resulted in recording log entry.
	UserId bigint null,
	--Name of the user who initated action which resulted in recording log entry.
	UserName nvarchar(100) null,
	--Operating system used by the user.
	UserOS varchar(36) null,
	--Version of the operating system used by the user.
	UserOSVersion varchar(36) null,
	--Browser used by end user.
	UserBrowser varchar(36) null,
	--Version of the browser used by end user.
	UserBrowserVersion varchar(36) null,
	--Identifier of the resource type which is a subject of the recorded activity.
	ResourceTypeId bigint null,
	--Name of the resource type which is a subject of the recorded activity.
	ResourceTypeName varchar(100) null,
	--Identifier of the resource (object, entity) which is subject of the action being logged.
	ResourceId bigint null,
	--name of the resource (object, entity) which is subject of the action being logged.
	ResourceName nvarchar(100) null,
	--name which is used by user (username) to access the application.
	EnvironmentUserName varchar(256) null,
	--Name oof the machine used bz the user to execute action.
	MachineName varchar(256) null,
	--Unique identifier of the request initiated. It could be shared among multiple log entries to identify complex action with more atomic parts.
	RequestId varchar(36) null,
	--Identifies endpoint used to make the request.
	RequestUrl nvarchar(2000) null,
	--Identifies type of the request in the form of HTTP verb: GET, POST, PATCH, DELETE, PUT...
	RequestType varchar(36) null,
	--Represent content of the request body (in JSON format).
	RequestContent nvarchar(max) null,
	--Identifies date and time when request is accepted.
	RequestTimeStamp datetime null,
	--Represent content of the response body (in JSON format).
	ResponseContent nvarchar(max) null,
	--Specified HTTP status code of the response.
	StatusCode int null,
	--Identifies date and time when response is generated.
	ResponseTimeStamp datetime null,
	--Duration
	Duration bigint null
)
go