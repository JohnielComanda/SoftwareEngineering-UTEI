import React, { useState, useEffect } from "react";
import "../../../css/OutputSpace.css";

const EffiencyBar = (props) => {
  const [width, setWidth] = useState(0);
  const [color, setColor] = useState("");
  console.log(props.score);

  useEffect(() => {
    if (props.score === 1) {
      setWidth(116);
      setColor("#ff0000");
    } else if (props.score === 2) {
      setWidth(232);
      setColor("#ffa700");
    } else if (props.score === 3) {
      setWidth(348);
      setColor("#fff400");
    } else if (props.score === 4) {
      setWidth(464);
      setColor("#a3ff00");
    } else if (props.score === 5) {
      setWidth(580);
      setColor("#2cba00");
    }
  }, [props.score]);

  const barStyle = {
    width: width + "px",
    backgroundColor: color,
  };

  return (
    <div className="bar-container">
      <div className="bar" style={barStyle}>
        <h2 className="score">{props.score}</h2>
      </div>
    </div>
  );
};
export default EffiencyBar;
