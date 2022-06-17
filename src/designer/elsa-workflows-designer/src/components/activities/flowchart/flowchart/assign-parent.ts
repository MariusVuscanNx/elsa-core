import {Graph, Rectangle, Node} from "@antv/x6";
import {camelCase} from 'lodash';
import {Activity} from "../../../../models";

export function assignParent(graph: Graph, node: Node){
  const underlyingNodes = graph.getNodesUnderNode(node);

  if (underlyingNodes.length > 0) {
    const underlyingNode = underlyingNodes[0];
    const underlyingActivity = underlyingNode.data as Activity;
    const underlyingView: any = graph.findView(underlyingNode);
    const portElements: Array<HTMLElement> = underlyingView.selectors.foContent.getElementsByClassName('activity-port');

    if (portElements.length == 0)
      return;

    const movedNodeView = graph.findView(node);
    const movedNodeViewRect = movedNodeView.getBBox();

    for (const portElement of portElements) {
      const portRect = Rectangle.create(portElement.getBoundingClientRect());
      const localPortRect = Rectangle.create(graph.pageToLocal(portRect));

      if (movedNodeViewRect.intersectsWithRect(localPortRect)) {
        const portName =  camelCase(portElement.dataset.portName);
        const childActivity = node.data as Activity;
        underlyingActivity[portName] = childActivity;
        graph.removeCell(node);
        break;
      }
    }

  }
}
