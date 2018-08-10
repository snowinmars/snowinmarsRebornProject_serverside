import React from 'react';
import ReactDOM from 'react-dom';
import './index.scss';
import './../src/css/flex.scss'
import './../src/css/grid.scss'
import Head from './react/components/Head/Head';
import registerServiceWorker from './registerServiceWorker';

ReactDOM.render(<Head />, document.getElementById('root'));
registerServiceWorker();
