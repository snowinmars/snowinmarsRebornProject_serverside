import React, { Component } from 'react';
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table';
import './../../../../../node_modules/react-bootstrap-table/dist/react-bootstrap-table.min.css';

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

    renderShowsTotal(start, to, total) {
        return (
            <span>
                From {start} to {to}, totals is {total}&nbsp;&nbsp;(its a customize text)
            </span>
        )
    }

    render() {
        const options = {
            page: 1,  // which page you want to show as default
            sizePerPageList: [ {
                    text: '5', value: 5
                }, {
                    text: '10', value: 10
                }, {
                    text: 'All', value: this.state.response.data.length
                }
            ], // you can change the dropdown list for size per page
            sizePerPage: 5,  // which size per page you want to locate as default
            pageStartIndex: 1, // where to start counting the pages
            paginationSize: 3,  // the pagination bar size.
            prePage: 'Prev', // Previous page button text
            nextPage: 'Next', // Next page button text
            firstPage: 'First', // First page button text
            lastPage: 'Last', // Last page button text
            paginationShowsTotal: this.renderShowsTotal,  // Accept bool or function
            paginationPosition: 'bottom'  // default is bottom, top and both is all available
            // hideSizePerPage: true > You can hide the dropdown for sizePerPage
            // alwaysShowAllBtns: true // Always show next and previous button
            // withFirstAndLast: false > Hide the going to First and Last page button
        };

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
