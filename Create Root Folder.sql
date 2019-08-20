/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.2.349
 * Time: 8/20/2019 11:47:09 AM
 ************************************************************/

USE [PhotographyAutomationDB]
GO
INSERT [dbo].[Photos]
  (
    [stream_id],
    [file_stream],
    [name],
    [path_locator],
    [creation_time],
    [last_write_time],
    [last_access_time],
    [is_directory],
    [is_offline],
    [is_hidden],
    [is_readonly],
    [is_archive],
    [is_system],
    [is_temporary]
  )
VALUES
  (
    N'74373939-96c1-e911-a1b2-0026b9dc4e9b',
    NULL,
    N'Root',
    N'/11160258252946.278488092321505.1755023611/',
    CAST(N'2019-08-18T13:27:37.1327040+04:30' AS DATETIMEOFFSET),
    CAST(N'2019-08-18T13:27:37.1327040+04:30' AS DATETIMEOFFSET),
    CAST(N'2019-08-18T13:27:37.1327040+04:30' AS DATETIMEOFFSET),
    1,
    0,
    0,
    0,
    0,
    0,
    0
  )
GO
