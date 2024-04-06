using Elsa.Workflows.Activities;
using Elsa.Workflows.State;

namespace Elsa.Workflows.Runtime.Contracts;

/// <summary>
/// Represents a workflow canceler.
/// </summary>
public interface IWorkflowCanceler
{
    /// <summary>
    /// Cancels the specified workflow.
    /// </summary>
    /// <param name="workflow">The workflow definition.</param>
    /// <param name="workflowState">The workflow state to cancel.</param>
    /// <param name="cancellationToken">An optional cancellation token.</param>
    Task<WorkflowState> CancelWorkflowAsync(Workflow workflow, WorkflowState workflowState, CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancels the specified workflow execution context.
    /// </summary>
    /// <param name="workflowExecutionContext">The workflow execution context to cancel.</param>
    /// <param name="cancellationToken">An optional cancellation token.</param>
    Task CancelWorkflowAsync(WorkflowExecutionContext workflowExecutionContext, CancellationToken cancellationToken = default);
}