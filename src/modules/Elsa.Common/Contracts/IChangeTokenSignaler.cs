﻿using Microsoft.Extensions.Primitives;

namespace Elsa.Common.Contracts;

/// <summary>
/// Provides change tokens for memory caches, allowing code to evict cache entries by triggering a signal.
/// </summary>
public interface IChangeTokenSignaler
{
    /// <summary>
    /// Gets a change token for the specified key.
    /// </summary>
    IChangeToken GetToken(string key);

    /// <summary>
    /// Triggers the change token for the specified key.
    /// </summary>
    void TriggerToken(string key);
}