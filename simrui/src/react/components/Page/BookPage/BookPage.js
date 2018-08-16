import React, { Component } from 'react';
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table';
import './../../../../../node_modules/react-bootstrap-table/dist/react-bootstrap-table.min.css';
import './BookPage.scss';
import AuthorList from './AuthorList';
import BookExpand from './BookExpand';

var Config = require('Config');

class BookPage extends Component {
    constructor(props) {
        super(props);

        var defaultUser = {
            title: 'Loading...',
            authors: [
                {
                    name: {
                        givenName: 'Loading...',
                        fullMiddleName: 'Loading...',
                        familyName: 'Loading...',
                        key: 0
                    }
                }
            ],
            year: 'Loading...',
            imageUrl: 'Loading...',
            additionalInfo: 'Loading...',
            bookshelf: 'Loading...',
            flibustaUrl: 'Loading...',
            libRusEcUrl: 'Loading...',
            liveLibUrl: 'Loading...',
            owner: 'Loading...',
            pageCount: 'Loading...',
            key: 0
        };

        var data = [];

        for (var i = 0; i < 10; i++) {
            data.push(defaultUser);
        }

        this.state = {
            isInit: false,
            response: {
                code: -1,
                data: data
            }
        };

        this.getRow = this.getRow.bind(this);
    }

    componentDidMount() {
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

    isExpandableRow() {
        return true;
    }

    expandComponent(row) {
        return <BookExpand row={row} />;
    }

    authorsFormatter(cell) {
        return <AuthorList authors={cell} />;
    }

    render() {
        const options = Config.bootstrapTableOptions;

        const table = <BootstrapTable
            ref="table"
            data={this.state.response.data}
            striped
            hover
            pagination
            expandableRow={this.isExpandableRow}
            expandComponent={this.expandComponent}
            options={options}
        >
            <TableHeaderColumn dataField="title" isKey dataSort>
                Title
                </TableHeaderColumn>

            <TableHeaderColumn
                dataField="authors"
                dataSort
                dataFormat={this.authorsFormatter}
            >
                Authors
                </TableHeaderColumn>

            <TableHeaderColumn dataField="year" dataSort>
                Year
                </TableHeaderColumn>
        </BootstrapTable>

        const loader = !this.state.inInit && <div className="simr-loader"></div>

        return (
            <div>
                {loader}
                {table}
            </div>
        );
    }
}

export default BookPage;
