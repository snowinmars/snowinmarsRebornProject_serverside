import React, { Component } from 'react';
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table';
import './../../../../../node_modules/react-bootstrap-table/dist/react-bootstrap-table.min.css';
import './SiberiaPage.scss';

var Config = require('Config');
var Lib = require('./../../../Lib/componentUtils');

class SiberiaPage extends Component {
    constructor(props) {
        super(props);

        var data = this.getDefaultData();

        this.state = {
            isInit: false,
            gotApiError: false,
            hasErrors: false,
            response: {
                code: -1,
                data: data
            }
        };

        this.options = Config.bootstrapTableOptions;

        this.getRow = this.getRow.bind(this);
    }

    componentDidMount() {
        Lib.fetchAndHandle({
            uri: Config.apiurl.siberia.filter,
            onSuccess: json =>
                this.setState({
                    response: JSON.parse(json),
                    isInit: true
                }),
            onError: err =>
                this.setState({
                    gotApiError: true,
                    hasErrors: true,
                    isInit: false
                })
        });
    }

    render() {
        const loader = this.getLoader();

        const table = this.getTable(this.options);

        return (
            <div>
                {loader}
                {table}
            </div>
        );
    }

    getDefaultData() {
        var defaultUser = {
            name: 'Loading...',
            enviroment: 'Loading...',
            key: 0
        };
        
        var data = [];

        for (var i = 0; i < 10; i++) {
            data.push(defaultUser);
        }

        return data;
    }

    getRow(i) {
        return this.state.response.data[i.index];
    }

    getTable(options) {
        return <BootstrapTable ref="table" data={this.state.response.data} striped hover pagination options={options}>
                <TableHeaderColumn dataField="name" isKey dataSort>
                    Name
                </TableHeaderColumn>

                <TableHeaderColumn dataField="environment" dataSort>
                    Enviroment
                </TableHeaderColumn>
            </BootstrapTable>;
    }

    getLoader() {
        var loaderClass = '';

        if (this.state.gotApiError) {
            loaderClass += ' simr-loader-api-error ';
        }

        if (this.state.isInit) {
            loaderClass += ' simr-loader hidden ';
        } else {
            loaderClass += ' simr-loader ';
        }

        const loader = (
            <div
                className={
                    loaderClass +
                    'simr-flex simr-flex-align-center simr-flex-justify-center'
                }
            >
                <div class="sk-folding-cube">
                    <div class="sk-cube1 sk-cube" />
                    <div class="sk-cube2 sk-cube" />
                    <div class="sk-cube4 sk-cube" />
                    <div class="sk-cube3 sk-cube" />
                </div>
            </div>
        );
        return loader;
    }
}

export default SiberiaPage;
