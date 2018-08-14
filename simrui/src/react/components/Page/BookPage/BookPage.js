import React, { Component } from 'react';
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table';
import './../../../../../node_modules/react-bootstrap-table/dist/react-bootstrap-table.min.css';
import './BookPage.scss';

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
        const options = Config.bootstrapTableOptions;

        return <BootstrapTable ref="table" data={this.state.response.data} striped hover pagination options={options}>
                <TableHeaderColumn dataField="title" isKey dataSort>
                    Title
                </TableHeaderColumn>

                <TableHeaderColumn dataField="pageCount" dataSort>
                    Page Count
                </TableHeaderColumn>

                <TableHeaderColumn dataField="year">
                    Year
                </TableHeaderColumn>
            </BootstrapTable>;
    }
}

export default BookPage;
