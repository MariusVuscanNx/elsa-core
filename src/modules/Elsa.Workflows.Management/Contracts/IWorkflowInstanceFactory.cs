using Elsa.Workflows.Management.Entities;
using Elsa.Workflows.Management.Params;
using Elsa.Workflows.Management.Requests;
using Elsa.Workflows.State;

namespace Elsa.Workflows.Management.Contracts;

/// <summary>
/// Creates new <see cref="WorkflowInstance"/> objects.
/// </summary>
public interface IWorkflowInstanceFactory
{
    /// <summary>
    /// Creates a new <see cref="WorkflowState"/> object.
    /// </summary>
    WorkflowState CreateWorkflowState(CreateWorkflowInstanceParams @params);

    /// <summary>
    /// Creates a new <see cref="WorkflowInstance"/> object.
    /// </summary>
    WorkflowInstance CreateWorkflowInstance(CreateWorkflowInstanceParams @params);
}