//-----------------------------------------------------------------------
// <copyright file="ForeachStatement.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. If you cannot locate the  
//   Microsoft Public License, please send an email to dlr@microsoft.com. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace Microsoft.StyleCop.CSharp
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A foreach-statement.
    /// </summary>
    /// <subcategory>statement</subcategory>
    public sealed class ForeachStatement : Statement
    {
        #region Private Fields

        /// <summary>
        /// The variable declared in the foreach-statement declaration.
        /// </summary>
        private VariableDeclarationExpression variable;

        /// <summary>
        /// The item being interated over.
        /// </summary>
        private Expression item;

        /// <summary>
        /// The statement that is embedded within this foreach-statement.
        /// </summary>
        private Statement embeddedStatement;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the ForeachStatement class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="variable">The variable declared in foreach-statement declaration.</param>
        /// <param name="item">The item being iterated over.</param>
        internal ForeachStatement(CodeUnitProxy proxy, VariableDeclarationExpression variable, Expression item)
            : base(proxy, StatementType.Foreach)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertNotNull(variable, "variable");
            Param.AssertNotNull(item, "item");

            this.variable = variable;
            this.item = item;
        }

        #endregion Internal Constructors

        #region Public Override Properties

        /// <summary>
        /// Gets the variables defined within this code unit.
        /// </summary>
        public override IList<IVariable> Variables
        {
            get
            {
                return this.variable.GetVariables();
            }
        }

        #endregion Public Override Properties

        #region Public Properties

        /// <summary>
        /// Gets the variable declared in the foreach-statement declaration.
        /// </summary>
        public VariableDeclarationExpression Variable
        {
            get
            {
                return this.variable;
            }
        }

        /// <summary>
        /// Gets the item being iterated over.
        /// </summary>
        public Expression Item
        {
            get
            {
                return this.item;
            }
        }

        /// <summary>
        /// Gets the statement that is embedded within this foreach-statement.
        /// </summary>
        public Statement EmbeddedStatement
        {
            get
            {
                return this.embeddedStatement;
            }

            internal set
            {
                Param.AssertNotNull(value, "EmbeddedStatement");
                this.embeddedStatement = value;
            }
        }

        #endregion Public Properties
    }
}