import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import './../src/css/flex.css'
import './../src/css/grid.css'
import Head from './react/components/Head/Head';
import registerServiceWorker from './registerServiceWorker';

ReactDOM.render(<Head />, document.getElementById('root'));
registerServiceWorker();
