import './BookFilter.scss';

import React, { PureComponent } from 'react';

const status = {
    text: 'text',
    blocks: 'blocks'
};

class BookFilter extends PureComponent {
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
        const blockSplitCharacter = ';';

        const nodes = rawQuery
            .split(blockSplitCharacter)
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
            return (result = result + ' ; ' + current);
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
                <div className='simr-book-table-filters' ref={this.blocks}>
                    {this.state.nodes.map(node => {
                        return (
                            <span
                                data-value={node}
                                className='simr-book-table-filter'
                                onClick={this.onBlockClick}
                            >
                                {node}
                            </span>
                        );
                    })}
                </div>
            );
        }

      

        return (
            <div className='simr-flex simr-book-table-search-and-filter'>
                <input
                    type='text'
                    className='simr-form-control simr-book-table-search '
                    value={this.state.text}
                    ref={this.input}
                    onBlur={this.onInputBlur}
                    onFocus={this.onInputFocus}
                    onChange={this.onInputChange}
                />

                {element}
            </div>
        );
    }
}

export default BookFilter;
