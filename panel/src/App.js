import { Navigation } from "./navigation";
// import { fab } from "@fortawesome/free-brands-svg-icons";
import {
  faCheckSquare,
  faCoffee,
  faPlus,
  faCheckCircle,
  faPlusCircle,
  faTrash,
  faEdit,
  faSearch,
  faBackward,
  faBackspace,
  faArrowLeft,
} from "@fortawesome/free-solid-svg-icons";
import { library } from "@fortawesome/fontawesome-svg-core";

library.add(
  faCheckSquare,
  faCoffee,
  faPlus,
  faCheckCircle,
  faPlusCircle,
  faTrash,
  faEdit,
  faSearch,
  faBackward,
  faBackspace,
  faArrowLeft
);

function App() {
  return <Navigation />;
}

export default App;
