import React, { PureComponent } from 'react';

class BookFilter extends PureComponent {
    constructor(props) {
        super(props);

        this.state = {
            blocks: []
        };
    }

    onInputChange = e => this.update(e.target.value);

    update = text => {
        var nodes = text.split(';');

        if (nodes.length === 1) {
            this.setState({ blocks: [] });
            return;
        }

        var count = nodes.length;
        var newBlocks = [];

        for (var i = 0; i < count; i++) {
            var node = nodes[i];

            if (node.startsWith('title:')) {
                var value = node.split(':')[1];

                var newBlock = {
                    type: 'title',
                    value: value
                };

                newBlocks.push(newBlock);
            }
        }

        this.setState({ blocks: newBlocks }, () =>
            console.log(this.state.blocks)
        );
    };

    render() {
        return (
            <input
                type="text"
                class="form-control"
                placeholder="Filter"
                onChange={this.onInputChange}
            />
        );
    }
}

export default BookFilter;
