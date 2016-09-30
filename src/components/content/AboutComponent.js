'use strict';

import React from 'react';

require('styles/content/About.css');

let groupMembers = [{
  name: 'Fredrik Berglund',
  email: 'mahlst@kth.se',
  image:require('../../images/fredrik-berglund.jpg')
}, {
  name: 'Karl Andersson',
  email: 'karl9@kth.se',
  image:require('../../images/karl-andersson.jpg')
}, {
  name: 'Karl Gylleus',
  email: 'gylleus@kth.se',
  image:require('../../images/karl-gylleus.jpg')
}, {
  name: 'Marcus Ahlström',
  email: 'fberglund@kth.se',
  image:require('../../images/marcus-ahlstroem.jpg')
}, {
  name: 'Rodrigo Roa Rodríguez',
  email: 'rorrkth.se',
  image:require('../../images/rodrigo-roa-rodriguez.jpg')
}, {
  name: 'Staffan Sandberg',
  email: 'stsand@kth.se',
  image:require('../../images/staffan-sanberg.jpg')
}]

class AboutComponent extends React.Component {
  render() {
    return (
      <div className="about-component">
        {groupMembers.map(member=> <img src={member.image} key={member.name}  alt={member.name} className="member-image"/>)}
      </div>
    );
  }
}

AboutComponent.displayName = 'ContentAboutComponent';

// Uncomment properties you need
// AboutComponent.propTypes = {};
// AboutComponent.defaultProps = {};

export default AboutComponent;
