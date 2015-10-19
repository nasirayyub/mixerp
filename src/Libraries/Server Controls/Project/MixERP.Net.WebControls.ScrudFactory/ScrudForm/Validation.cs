using MixERP.Net.i18n.Resources;
using System;

namespace MixERP.Net.WebControls.ScrudFactory
{
    public partial class ScrudForm
    {
        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.TableSchema))
            {
                throw new InvalidOperationException(Titles.TableSchemaEmptyExceptionMessage);
            }

            if (string.IsNullOrWhiteSpace(this.Table))
            {
                throw new InvalidOperationException(Titles.TableEmptyExceptionMessage);
            }

            if (string.IsNullOrWhiteSpace(this.ViewSchema))
            {
                throw new InvalidOperationException(Titles.ViewSchemaEmptyExceptionMessage);
            }

            if (string.IsNullOrWhiteSpace(this.View))
            {
                throw new InvalidOperationException(Titles.ViewEmptyExceptionMessage);
            }

            if (string.IsNullOrWhiteSpace(this.KeyColumn))
            {
                throw new InvalidOperationException(Titles.KeyColumnEmptyExceptionMessage);
            }
        }
    }
}