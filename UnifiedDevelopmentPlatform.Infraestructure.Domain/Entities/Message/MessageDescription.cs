﻿using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message
{
    [ComplexType]
    /// <summary>
    /// Description of Mensagem.
    /// </summary>
    public static class MessageDescription
    {
        /// <summary>
        /// No message.
        /// </summary>
        public static string NoMessage => "ERROR MESSAGE DON'T SPECIFIELD.";

        /// <summary>
        /// Message initial of build of UDP.
        /// </summary>
        public static string Initial => "WAS STARTED THE CREATION OF UNIFIED DEVELOPMENT PLATFORM - UDP.";

        /// <summary>
        /// Platform is Windows Ok.
        /// </summary>
        public static string PlatformIsWindowsOk => "PLATFORM TO BUILD UNIFIED DEVELOPMENT PLATFORM IS WINDOWS.";

        /// <summary>
        /// Platform is Windows erro.
        /// </summary>
        public static string PlatformIsWindowsErro => "THIS VERSION OF (UNIFIED DEVELOPMENT PLATFORM) DON'T RUN IN CROSS CROSS PLATFORM. ONLY WINDOWS.";

        #region Filter action.

        /// <summary>
        /// Error filter action context controller.
        /// </summary>
        public static string ErrorFilterActionContextController => "ERROR OCORRED OF THE CREATION THE";

        /// <summary>
        /// Error filter action context tables.
        /// </summary>
        public static string ErrorFilterActionContextTables => "ERROR OCORRED IN THE VALIDATION OF TABLES.";

        /// <summary>
        /// Error filter action context fields.
        /// </summary>
        public static string ErrorFilterActionContextFields => "ERROR OCORRED IN THE VALIDATION OF FIELDS.";

        #region The validation of filter action.

        /// <summary>
        /// Message default to service validation.
        /// </summary>
        public static string MessageDefaultToServiceValidation => "IS NECESSARY FOR GENERATE THE APP.";

        /// <summary>
        /// Message to the model state is ok.
        /// </summary>
        public static string MessageUdpModelStateIsOk => $"THE (JSON) {MessageDescription.MessageDefaultToServiceValidation}";

        /// <summary>
        /// Message to the script metadata is ok.
        /// </summary>
        public static string MessageUdpScriptMetadataIsOk => $"THE (METADATA) {MessageDescription.MessageDefaultToServiceValidation}";

        /// <summary>
        /// Message to the metadata is base64 ok.
        /// </summary>
        public static string MessageUdpMetadataIsBase64Ok => $"THE (METADATA) ON THE FORMAT BASE64 {MessageDescription.MessageDefaultToServiceValidation}";

        /// <summary>
        /// Message to the development environment is ok.
        /// </summary>
        public static string MessageUdpDevelopmentEnvironmentIsOk => $"THE (DEVELOPMENT ENVIRONMENT) {MessageDescription.MessageDefaultToServiceValidation}";

        /// <summary>
        /// Message to the databases is ok.
        /// </summary>
        public static string MessageUdpDatabasesIsOk => $"THE (DATABASES) {MessageDescription.MessageDefaultToServiceValidation}";

        /// <summary>
        /// Message to the databases engine is ok.
        /// </summary>
        public static string MessageUdpDatabasesEngineIsOk => $"THE (DATABASES ENGINE) {MessageDescription.MessageDefaultToServiceValidation}";

        /// <summary>
        /// Message to the forms is ok.
        /// </summary>
        public static string MessageUdpFormIsOk => $"THE (FORMS) {MessageDescription.MessageDefaultToServiceValidation}";

        /// <summary>
        /// Message to the architecture is ok.
        /// </summary>
        public static string MessageUdpArchitectureIsOk => $"THE (ARCHITECTURE) {MessageDescription.MessageDefaultToServiceValidation}";

        #endregion The validation of filter action.

        #endregion Filter action.

        #region Service directory.

        /// <summary>
        /// Message default to service validation.
        /// </summary>
        public static string ErrorCreateAllDirectory => "ERRO TO CREATE DIRECTORY DEFAULT OF UNIFIED DEVELOPMENT PLATFORM - UDP.";

        /// <summary>
        /// Build of all directory standard of solution.
        /// </summary>
        public static string BuildDirectoryStandardOfSolution => "STARTING OF THE CREATION THE INITIAL OF THE DIRECTORY STANDARD.";

        /// <summary>
        /// Directory root is empty.
        /// </summary>
        public static string DirectoryRootIsEmpty => "DIRECTORY ROOT IS EMPTY IN SERVICE DIRECTORY.";

        #endregion Service directory.

        #region ServiceMetadataTables.
        /// <summary>
        /// Invalid Base 64.
        /// </summary>
        public static string InvalidBase64 => "THIS BASE 64 ISA INVALID TO GENERATED THE TABLES NAME.";
        #endregion ServiceMetadataTables.

        #region ServiceMetadata.

        /// <summary>
        /// Success at the receive and save all table and fields of schema database.
        /// </summary>
        public static string SuccessAtTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase => "SUCCESS AT THE RECEIVE AND SAVE ALL TABLE AND FIELDS OF SCHEMA DATABASE.";

        /// <summary>
        /// Error receive and save all table and fields of schema database.
        /// </summary>
        public static string ErrorReceiveAndSaveAllTableAndFieldsOfSchemaDatabase => "ERROR OCCURRED AT RETURN ALL OF THE TABLE AND FIELDS OF SCHEMA DATABASEIN THE VALIDATION OF FIELDS.";

        /// <summary>
        /// Call start receive and save all table and fields of schema database.
        /// </summary>
        public static string CallStartReceiveAndSaveAllTableAndFieldsOfSchemaDatabase => "CALL START RECEIVE AND SAVE ALL TABLE AND FIELDS OF SCHEMA DATABASE.";

        /// <summary>
        /// Load all of the table and fields of schema database.
        /// </summary>
        public static string LoadAllOfTheTableAndFieldsOfSchemaDatabase => "LOAD ALL OF THE TABLE AND FIELDS OF SCHEMA DATABASE.";

        /// <summary>
        /// Decrypt ok of the receive and save all table and fields of schema database.
        /// </summary>
        public static string DecryptOkOfTheReceiveAndSaveAllTableAndFieldsOfSchemaDatabase => "DECRYPT OK OF THE RECEIVE AND SAVE ALL TABLE AND FIELDS OF SCHEMA DATABASE.";

        /// <summary>
        /// Call start to the Select parameters the kinds of databases.
        /// </summary>
        public static string CallStartToTheSelectParametersTheKindsOfDatabases => "CALL START TO THE SELECT PARAMETERS THE KINDS OF DATABASES.";

        /// <summary>
        /// Call start to the Select parameters the kinds of forms.
        /// </summary>
        public static string CallStartToTheSelectParametersTheKindsOfForms => "CALL START TO THE SELECT PARAMETERS THE KINDS OF FORMS.";

        /// <summary>
        /// Call start to the Select parameters the kinds of development enviroment.
        /// </summary>
        public static string CallStartToTheSelectParametersTheKindsOfDevelopmentEnviroment => "CALL START TO THE SELECT PARAMETERS THE KINDS OF DEVELOPMENT ENVIROMENT.";

        /// <summary>
        /// Call start to the Select parameters the kinds of databases engine.
        /// </summary>
        public static string CallStartToTheSelectParametersTheKindsOfDatabasesEngine => "CALL START TO THE SELECT PARAMETERS THE KINDS OF DATABASES ENGINE.";

        /// <summary>
        /// Call start to the Select parameters the kinds of architecture patterns.
        /// </summary>
        public static string CallStartToTheSelectParametersTheKindsOfArchitecturePatterns => "CALL START TO THE SELECT PARAMETERS THE KINDS OF ARCHITECTURE PATTERNS.";

        /// <summary>
        /// Call start to the Select parameters the kinds of unifiedDevelopment platform.
        /// </summary>
        public static string CallStartToTheSelectParametersTheKindsOfUnifiedDevelopmentPlatform => "CALL START TO THE SELECT PARAMETERS THE KINDS OF UNIFIEDDEVELOPMENT PLATFORM.";

        #endregion ServiceMetadata.

        #region ServiceCrypto.

        /// <summary>
        /// Call start to the encrypt.
        /// </summary>
        public static string CallStartToTheEncrypt => "CALL START TO THE ENCRYPT.";

        /// <summary>
        /// Success start to the encrypt.
        /// </summary>
        public static string SuccessToTheEncrypt => "SUCCESS START TO THE ENCRYPT.";

        /// <summary>
        /// Error start to the encrypt.
        /// </summary>
        public static string ErrorToTheEncrypt => "ERROR START TO THE ENCRYPT.";

        /// <summary>
        /// Call start to the decrypt.
        /// </summary>
        public static string CallStartToTheDecrypt => "CALL START TO THE DECRYPT.";

        /// <summary>
        /// Success start to the decrypt.
        /// </summary>
        public static string SuccessToTheDecrypt => "SUCCESS START TO THE DECRYPT.";

        /// <summary>
        /// Error start to the decrypt.
        /// </summary>
        public static string ErrorToTheDecrypt => "ERROR START TO THE DECRYPT.";

        /// <summary>
        /// Call start to the decode base 64.
        /// </summary>
        public static string CallStartToTheDecodeBase64 => "CALL START TO THE DECODE BASE 64.";

        /// <summary>
        /// Success start to the decode base 64.
        /// </summary>
        public static string SuccessToTheDecodeBase64 => "SUCCESS START TO THE DECODE BASE 64.";

        /// <summary>
        /// Error start to the decode base 64.
        /// </summary>
        public static string ErrorToTheDecodeBase64 => "ERROR START TO THE DECODE BASE 64.";

        #endregion ServiceCrypto.
    }
}