﻿using System;

namespace Alpaca.Markets
{
    /// <summary>
    /// Encapsulates data required for placing the stop order on the Alpaca REST API.
    /// </summary>
    public sealed class StopOrder : SimpleOrderBase
    {
        internal StopOrder(
            String symbol,
            Int64 quantity,
            OrderSide side,
            Decimal stopPrice
        )
            : base(
                symbol, quantity, side,
                OrderType.Stop) =>
            StopPrice = stopPrice;

        /// <summary>
        /// Gets or sets the new order stop price.
        /// </summary>
        public Decimal StopPrice { get; }

        internal override JsonNewOrder GetJsonRequest() =>
            base.GetJsonRequest()
                .WithStopPrice(StopPrice);
    }
}
