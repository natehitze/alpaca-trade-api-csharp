﻿namespace Alpaca.Markets.Extensions;

/// <summary>
/// Set of extension methods for the <see cref="IHistoricalBarsClient{TRequest}"/> interface.
/// </summary>
public static partial class HistoricalBarsClientExtensions
{
    private sealed class RequestFactory<TRequest>
        where TRequest : class, IHistoricalRequest<TRequest, IBar>
    {
        private RequestFactory() { }

        public static RequestFactory<TRequest> Instance { get; } = new();

        public TRequest Create(
            String symbol,
            Interval<DateOnly> timeInterval) =>
            createImpl(symbol, timeInterval) ?? throw new InvalidCastException();

        private TRequest? createImpl(
            String symbol,
            Interval<DateOnly> timeInterval) =>
            this switch
            {
                RequestFactory<HistoricalBarsRequest> =>
                    new HistoricalBarsRequest(symbol, BarTimeFrame.Day, timeInterval.AsTimeInterval()) as TRequest,
                RequestFactory<HistoricalCryptoBarsRequest> =>
                    new HistoricalCryptoBarsRequest(symbol, BarTimeFrame.Day, timeInterval.AsTimeInterval()) as TRequest,
                _ => throw new InvalidOperationException()
            };
    }

    /// <summary>
    /// Gets the average trade volume for the given <paramref name="symbol"/> and time interval
    /// between <paramref name="from"/> date to the <paramref name="into"/> date (inclusive).
    /// </summary>
    /// <param name="client">Target instance of the <see cref="IHistoricalBarsClient{TRequest}"/> interface.</param>
    /// <param name="symbol">Asset name for the data retrieval.</param>
    /// <param name="from">Filter data equal to or after this time.</param>
    /// <param name="into">Filter data equal to or before this time.</param>
    /// <returns>The pair of ADTV value and number of processed day bars.</returns>
    [UsedImplicitly]
    [CLSCompliant(false)]
    [ExcludeFromCodeCoverage]
    [Obsolete("Use another method overload that takes the DateOnly arguments.", false)]
    public static Task<(Decimal, UInt32)> GetAverageDailyTradeVolumeAsync<TRequest>(
        this IHistoricalBarsClient<TRequest> client,
        String symbol,
        DateTime from,
        DateTime into)
        where TRequest : HistoricalRequestBase, IHistoricalRequest<TRequest, IBar> =>
        GetAverageDailyTradeVolumeAsync(
            client, symbol, new Interval<DateOnly>(
                DateOnly.FromDateTime(from), DateOnly.FromDateTime(into)),
            CancellationToken.None);

    /// <summary>
    /// Gets the average trade volume for the given <paramref name="symbol"/> and time interval
    /// between <paramref name="from"/> date to the <paramref name="into"/> date (inclusive).
    /// </summary>
    /// <param name="client">Target instance of the <see cref="IHistoricalBarsClient{TRequest}"/> interface.</param>
    /// <param name="symbol">Asset name for the data retrieval.</param>
    /// <param name="from">Filter data equal to or after this time.</param>
    /// <param name="into">Filter data equal to or before this time.</param>
    /// <returns>The pair of ADTV value and number of processed day bars.</returns>
    [UsedImplicitly]
    [CLSCompliant(false)]
    public static Task<(Decimal, UInt32)> GetAverageDailyTradeVolumeAsync<TRequest>(
        this IHistoricalBarsClient<TRequest> client,
        String symbol,
        DateOnly from,
        DateOnly into)
        where TRequest : HistoricalRequestBase, IHistoricalRequest<TRequest, IBar> =>
        GetAverageDailyTradeVolumeAsync(
            client, symbol, from, into, CancellationToken.None);

    /// <summary>
    /// Gets the average trade volume for the given <paramref name="symbol"/> and time interval
    /// between <paramref name="from"/> date to the <paramref name="into"/> date (inclusive).
    /// </summary>
    /// <param name="client">Target instance of the <see cref="IHistoricalBarsClient{TRequest}"/> interface.</param>
    /// <param name="symbol">Asset name for the data retrieval.</param>
    /// <param name="from">Filter data equal to or after this time.</param>
    /// <param name="into">Filter data equal to or before this time.</param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
    /// </param>
    /// <returns>The pair of ADTV value and number of processed day bars.</returns>
    [UsedImplicitly]
    [CLSCompliant(false)]
    [ExcludeFromCodeCoverage]
    [Obsolete("Use another method overload that takes the DateOnly arguments.", false)]
    public static Task<(Decimal, UInt32)> GetAverageDailyTradeVolumeAsync<TRequest>(
        this IHistoricalBarsClient<TRequest> client,
        String symbol,
        DateTime from,
        DateTime into,
        CancellationToken cancellationToken)
        where TRequest : HistoricalRequestBase, IHistoricalRequest<TRequest, IBar> =>
        GetAverageDailyTradeVolumeAsync(
            client, symbol, new Interval<DateOnly>(
                DateOnly.FromDateTime(from), DateOnly.FromDateTime(into)),
            cancellationToken);

    /// <summary>
    /// Gets the average trade volume for the given <paramref name="symbol"/> and time interval
    /// between <paramref name="from"/> date to the <paramref name="into"/> date (inclusive).
    /// </summary>
    /// <param name="client">Target instance of the <see cref="IHistoricalBarsClient{TRequest}"/> interface.</param>
    /// <param name="symbol">Asset name for the data retrieval.</param>
    /// <param name="from">Filter data equal to or after this time.</param>
    /// <param name="into">Filter data equal to or before this time.</param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
    /// </param>
    /// <returns>The pair of ADTV value and number of processed day bars.</returns>
    [UsedImplicitly]
    [CLSCompliant(false)]
    public static Task<(Decimal, UInt32)> GetAverageDailyTradeVolumeAsync<TRequest>(
        this IHistoricalBarsClient<TRequest> client,
        String symbol,
        DateOnly from,
        DateOnly into,
        CancellationToken cancellationToken)
        where TRequest : HistoricalRequestBase, IHistoricalRequest<TRequest, IBar> =>
        GetAverageDailyTradeVolumeAsync(
            client, symbol, new Interval<DateOnly>(from, into), cancellationToken);

    /// <summary>
    /// Gets the average trade volume for the given <paramref name="symbol"/> and <paramref name="timeInterval"/>.
    /// </summary>
    /// <param name="client">Target instance of the <see cref="IHistoricalBarsClient{TRequest}"/> interface.</param>
    /// <param name="symbol">Asset name for the data retrieval.</param>
    /// <param name="timeInterval">Inclusive time interval for the ADTV calculation.</param>
    /// <returns>The pair of ADTV value and number of processed day bars.</returns>
    [UsedImplicitly]
    [CLSCompliant(false)]
    [ExcludeFromCodeCoverage]
    [Obsolete("Use another method overload that takes the Interval<DateOnly> argument.", false)]
    public static Task<(Decimal, UInt32)> GetAverageDailyTradeVolumeAsync<TRequest>(
        this IHistoricalBarsClient<TRequest> client,
        String symbol,
        IInclusiveTimeInterval timeInterval)
        where TRequest : HistoricalRequestBase, IHistoricalRequest<TRequest, IBar> =>
        GetAverageDailyTradeVolumeAsync(
            client, symbol, timeInterval, CancellationToken.None);

    /// <summary>
    /// Gets the average trade volume for the given <paramref name="symbol"/> and <paramref name="timeInterval"/>.
    /// </summary>
    /// <param name="client">Target instance of the <see cref="IHistoricalBarsClient{TRequest}"/> interface.</param>
    /// <param name="symbol">Asset name for the data retrieval.</param>
    /// <param name="timeInterval">Inclusive time interval for the ADTV calculation.</param>
    /// <returns>The pair of ADTV value and number of processed day bars.</returns>
    [UsedImplicitly]
    [CLSCompliant(false)]
    public static Task<(Decimal, UInt32)> GetAverageDailyTradeVolumeAsync<TRequest>(
        this IHistoricalBarsClient<TRequest> client,
        String symbol,
        Interval<DateOnly> timeInterval)
        where TRequest : HistoricalRequestBase, IHistoricalRequest<TRequest, IBar> =>
        GetAverageDailyTradeVolumeAsync(
            client, symbol, timeInterval, CancellationToken.None);

    /// <summary>
    /// Gets the average trade volume for the given <paramref name="symbol"/> and <paramref name="timeInterval"/>.
    /// </summary>
    /// <param name="client">Target instance of the <see cref="IHistoricalBarsClient{TRequest}"/> interface.</param>
    /// <param name="symbol">Asset name for the data retrieval.</param>
    /// <param name="timeInterval">Inclusive time interval for the ADTV calculation.</param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
    /// </param>
    /// <returns>The pair of ADTV value and number of processed day bars.</returns>
    [UsedImplicitly]
    [CLSCompliant(false)]
    [ExcludeFromCodeCoverage]
    [Obsolete("Use another method overload that takes the Interval<DateOnly> argument.", false)]
    public static Task<(Decimal, UInt32)> GetAverageDailyTradeVolumeAsync<TRequest>(
        this IHistoricalBarsClient<TRequest> client,
        String symbol,
        IInclusiveTimeInterval timeInterval,
        CancellationToken cancellationToken)
        where TRequest : HistoricalRequestBase, IHistoricalRequest<TRequest, IBar> =>
       GetAverageDailyTradeVolumeAsync(
           client, symbol,
           // ReSharper disable once ConditionalAccessQualifierIsNonNullableAccordingToAPIContract
           new Interval<DateOnly>(timeInterval?.From.asDateOnly(), timeInterval?.Into.asDateOnly()),
           cancellationToken);

    /// <summary>
    /// Gets the average trade volume for the given <paramref name="symbol"/> and <paramref name="timeInterval"/>.
    /// </summary>
    /// <param name="client">Target instance of the <see cref="IHistoricalBarsClient{TRequest}"/> interface.</param>
    /// <param name="symbol">Asset name for the data retrieval.</param>
    /// <param name="timeInterval">Inclusive time interval for the ADTV calculation.</param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
    /// </param>
    /// <returns>The pair of ADTV value and number of processed day bars.</returns>
    [UsedImplicitly]
    [CLSCompliant(false)]
    public static Task<(Decimal, UInt32)> GetAverageDailyTradeVolumeAsync<TRequest>(
        this IHistoricalBarsClient<TRequest> client,
        String symbol,
        Interval<DateOnly> timeInterval,
        CancellationToken cancellationToken)
        where TRequest : HistoricalRequestBase, IHistoricalRequest<TRequest, IBar> =>
        client.GetHistoricalBarsAsAsyncEnumerable(
                RequestFactory<TRequest>.Instance.Create(symbol, timeInterval), cancellationToken)
            .GetAverageDailyTradeVolumeAsync(cancellationToken);

    /// <summary>
    /// Gets the simple moving average values for the given list of <see cref="IBar"/> objects.
    /// </summary>
    /// <param name="client">Target instance of the <see cref="IHistoricalBarsClient{TRequest}"/> interface.</param>
    /// <param name="request">Original historical minute bars request (with empty next page token).</param>
    /// <param name="window">Size of the moving average window.</param>
    /// <returns>The list of bars with SMA values for all <see cref="IBar"/> properties.</returns>
    [UsedImplicitly]
    [CLSCompliant(false)]
    public static IAsyncEnumerable<IBar> GetSimpleMovingAverageAsync<TRequest>(
        this IHistoricalBarsClient<TRequest> client,
        TRequest request,
        Int32 window)
        where TRequest : HistoricalRequestBase, IHistoricalRequest<TRequest, IBar> =>
        GetSimpleMovingAverageAsync(
            client, request, window, CancellationToken.None);

    /// <summary>
    /// Gets the simple moving average values for the given list of <see cref="IBar"/> objects.
    /// </summary>
    /// <param name="client">Target instance of the <see cref="IHistoricalBarsClient{TRequest}"/> interface.</param>
    /// <param name="request">Original historical minute bars request (with empty next page token).</param>
    /// <param name="window">Size of the moving average window.</param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
    /// </param>
    /// <returns>The list of bars with SMA values for all <see cref="IBar"/> properties.</returns>
    [UsedImplicitly]
    [CLSCompliant(false)]
    public static IAsyncEnumerable<IBar> GetSimpleMovingAverageAsync<TRequest>(
        this IHistoricalBarsClient<TRequest> client,
        TRequest request,
        Int32 window,
        CancellationToken cancellationToken)
        where TRequest : HistoricalRequestBase, IHistoricalRequest<TRequest, IBar> =>
        client.GetHistoricalBarsAsAsyncEnumerable(request, cancellationToken)
            .GetSimpleMovingAverageAsync(window, cancellationToken);

    [ExcludeFromCodeCoverage]
    private static DateOnly? asDateOnly(
        this in DateTime? dateTime)
        => dateTime.HasValue ? DateOnly.FromDateTime(dateTime.Value) : null;
}
