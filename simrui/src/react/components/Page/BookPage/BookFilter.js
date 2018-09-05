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
    }

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
                    <span className="simr-filter-block">title:Whatever</span>
                </div>
                <div className="simr-filter-input-container">
                    <input
                        ref={this.input}
                        className="simr-form-control simr-filter-input simr-transparent-color"
                        type="text"
                        placeholder="Filter"
                        onFocus={this.onInputFocus}
                        onBlur={this.onInputBlur}
                    />
                </div>
            </div>
        );
    }
}

export default BookFilter;
