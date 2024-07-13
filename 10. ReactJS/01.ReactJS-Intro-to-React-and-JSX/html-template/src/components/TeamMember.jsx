import PropTypes from 'prop-types';

const TeamMember = ({ name, role, imageURL}) => {
    return (
        <div className="col-md-4">
            <div className="team-detail wow bounce" data-wow-delay="0.2s"> <img src={imageURL}
                className="img-fluid" />
                <h4>{name}</h4>
                <p>{role}</p>
            </div>
        </div>
    );
};

TeamMember.propTypes = {
    name: PropTypes.string.isRequired,
    role: PropTypes.string.isRequired,
    imageURL: PropTypes.string.isRequired
};

export default TeamMember;