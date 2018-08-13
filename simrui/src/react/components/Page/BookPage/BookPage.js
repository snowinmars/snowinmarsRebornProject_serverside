import React, { Component } from 'react';
import { Column, Table, AutoSizer } from 'react-virtualized';
import 'react-virtualized/styles.css';

var Config = require('Config');

class BookPage extends Component {
    constructor(props) {
        super(props);

        this.state = {
            response: {
                code: -1,
                data: []
            }
        };

        this.getRow = this.getRow.bind(this);

        fetch(Config.apiurl.book.filter, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'User-Agent': 'Fiddler'
            }
        })
            .then(res => res.json())
            .then(json => this.setState({ response: JSON.parse(json) }));
    }

    getRow(i) {
        return this.state.response.data[i.index];
    }

    render() {
        return (
            <AutoSizer>
                {({ height, width }) => (
                    <Table
                        height={height}
                        width={width}
                        headerHeight={20}
                        rowHeight={30}
                        rowCount={this.state.response.data.length}
                        rowGetter={this.getRow}
                    >
                        <Column lable="Title" dataKey="title" width={100} />
                        <Column lable="Authors" dataKey="authors" width={100} />
                        <Column lable="Owner" dataKey="owner" width={100} />
                        <Column
                            lable="PageCount"
                            dataKey="pageCount"
                            width={100}
                        />
                        <Column lable="Year" dataKey="year" width={100} />
                    </Table>
                )}
            </AutoSizer>
        );
    }
}

export default BookPage;
