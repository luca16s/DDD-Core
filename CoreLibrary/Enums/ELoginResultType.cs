// <copyright file="ELoginResultType.cs" company="Îakaré Software'oka">
//     Copyright (c) Îakaré Software'oka. All rights reserved. Licensed under the MIT license. See
//     LICENSE file in the project root for full license information.
// </copyright>

namespace CoreLibrary.Enums
{
    /// <summary>
    /// Enum com resultados possiveis após autenticação.
    /// </summary>
    public enum ELoginResultType
    {
        /// <summary>
        /// Retorna status de sucesso.
        /// </summary>
        Success,
        /// <summary>
        /// Retorna status de Não Autorizado.
        /// </summary>
        Unauthorized,
        /// <summary>
        ///  Retorna status de Cancelado pelo Usuário.
        /// </summary>
        CancelledByUser,
        /// <summary>
        /// Retorna status de Sem Conexão.
        /// </summary>
        NoNetworkAvailable,
        /// <summary>
        /// Retorna status de Erro desconhecido.
        /// </summary>
        UnknownError
    }
}