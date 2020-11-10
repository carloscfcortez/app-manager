import { Navigation } from "./navigation";
// import { fab } from "@fortawesome/free-brands-svg-icons";
import {
  faCheckSquare,
  faCoffee,
  faPlus,
  faCheckCircle,
  faPlusCircle,
} from "@fortawesome/free-solid-svg-icons";
import { library } from "@fortawesome/fontawesome-svg-core";

library.add(faCheckSquare, faCoffee, faPlus, faCheckCircle, faPlusCircle);

function App() {
  return <Navigation />;
}

export default App;
