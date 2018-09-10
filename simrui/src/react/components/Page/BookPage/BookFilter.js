import './BookFilter.scss';

import React, { PureComponent } from 'react';

class BookFilter extends PureComponent {
    constructor(props) {
        super(props);

        this.state = {
            blocks: [],
            isFocused: false
        };

        this.input = React.createRef();
        this.inputGhost = React.createRef();
    }

    onInputFocus = e => {
        this.inputGhost.current.classList.toggle('hidden');
        this.input.current.classList.toggle('simr-transparent-color');
    };

    onInputBlur = e => {
        this.inputGhost.current.classList.toggle('hidden');
        this.input.current.classList.toggle('simr-transparent-color');
    };

    onInputChange = e => {
        const tokenSeparator = ':';
        const text = e.target.value;

        const blocks = text.split(';');
        const blocksLength = blocks.length - 1; // -1 due to last segment always will be empty

        if (blocksLength === 0) {
            return;
        }

        let ghosts = [];

        for (let i = 0; i < blocksLength; i++) {
            const block = blocks[i].trim();

            const tokens = block.split(tokenSeparator);
            const prop = tokens[0];
            const value = tokens.slice(1).join(tokenSeparator);

            ghosts.push({ prop: prop, value: value });
        }

        if (ghosts.length !== 0) {
            console.log('ghosts', ghosts);
            this.setState({ blocks: ghosts }, function() {
                console.log('state', ghosts);
            });
        }
    };

    render() {
        return (
            <div
                className=""
                onFocus={this.onFocus}
                onBlur={this.onBlur}
                tabIndex="-1"
            >
                <div
                    ref={this.inputGhost}
                    className="simr-filter-blocks-container"
                >
                    {this.state.blocks.map(function(item) {
                        return (
                            <span className="simr-filter-block">
                                {item.prop}:{item.value}
                            </span>
                        );
                    })}
                </div>
                <div className="simr-filter-input-container">
                    <input
                        ref={this.input}
                        className="simr-form-control simr-filter-input simr-transparent-color"
                        type="text"
                        placeholder="Filter"
                        onFocus={this.onInputFocus}
                        onBlur={this.onInputBlur}
                        onChange={this.onInputChange}
                    />
                </div>
            </div>
        );
    }
}

export default BookFilter;
