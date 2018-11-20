import './Filter.scss';

import React, { PureComponent } from 'react';

const status = {
    text: 'text',
    blocks: 'blocks'
};

class Filter extends PureComponent {
    blockSplitCharacter = '[and]';

    constructor(props) {
        super(props);

        this.state = {
            nodes: [],
            text: '',
            status: status.text
        };

        this.input = React.createRef();
        this.blocks = React.createRef();
    }

    onInputBlur = () => {
        const rawQuery = this.input.current.value;

        const nodes = rawQuery
            .split(this.blockSplitCharacter)
            .filter(block => block && block.trim())
            .map(block => block.trim());

        this.setState({ nodes: nodes, status: status.blocks });
    };

    onInputFocus = () => {
        this.setState({ status: status.text });
    };

    nodesAsText = nodes => {
        if (!nodes || nodes.length === 0) {
            return '';
        }

        return nodes.reduce((result, current) => {
            return (result = [result , this.blockSplitCharacter, current].join(' '));
        });
    };

    onInputChange = e => {
        this.setState({ text: e.target.value });
    };

    onBlockClick = e => {
        const nodeValue = e.target.dataset.value;
        const newNodes = this.state.nodes.filter(node => node !== nodeValue);
        this.setState({
            nodes: newNodes,
            text: this.nodesAsText(newNodes)
        });
    };

    render() {
        let element = null;

        if (this.state.status === status.blocks) {
            element = (
                <div className="simr-filters" ref={this.blocks}>
                    {this.state.nodes.map(node => {
                        return (
                            <span
                                data-value={node}
                                className="simr-filter"
                                onClick={this.onBlockClick}
                            >
                                {node}
                            </span>
                        );
                    })}
                </div>
            );
        }

        const display = this.props.isBlock ? 'block' : 'inline';
        const width = this.props.isBlock ? '100%': 'inherit';
        return (
            <div className="simr-flex simr-search-and-filter">
                <input
                    type="text"
                    className="simr-form-control simr-input "
                    style={{display: display, width: width}}
                    value={this.state.text}
                    ref={this.input}
                    onBlur={this.onInputBlur}
                    onFocus={this.onInputFocus}
                    onChange={this.onInputChange}
                />

                <button className="simr-btn simr-apply-btn">
                    Apply
                </button>

                {element}
            </div>
        );
    }
}

export default Filter;
