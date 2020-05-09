using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using Ali.Ocr.Activities.Properties;
using Ali.Ocr.Models;
using Cloud.Ocr.Contracts;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;

namespace Ali.Ocr.Activities
{
    [LocalizedDisplayName(nameof(Resources.AliOcrClientActivity_DisplayName), typeof(Resources))]
    [LocalizedDescription(nameof(Resources.AliOcrClientActivity_Description), typeof(Resources))]
    public class AliOcrClientActivity : BaseOcrClientActivity
    {
        #region Properties

        [LocalizedDisplayName(nameof(Resources.AliOcrClientActivity_RecognizerConfig_DisplayName), typeof(Resources))]
        [LocalizedDescription(nameof(Resources.AliOcrClientActivity_RecognizerConfig_Description), typeof(Resources))]
        [LocalizedCategory(nameof(Resources.Input_Category), typeof(Resources))]
        public InArgument<DataTable> RecognizerConfig { get; set; }

        #endregion

        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (RecognizerConfig == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(RecognizerConfig)));

            base.CacheMetadata(metadata);
        }

        protected override IOcrClient GetOcrClient(AsyncCodeActivityContext context)
        {
            var recognizerConfig = RecognizerConfig.Get(context);

            return new AliOcrClient(recognizerConfig);
        }

        #endregion
    }
}

